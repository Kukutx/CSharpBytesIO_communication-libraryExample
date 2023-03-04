# BytesIO | C# 优雅处理通信中的粘包和断包（一）—— 处理固定长的的协议

## 前言

今天我们讲一下怎么用BytesIO里面的解包器优雅的解析带有协议的数据包。

## 什么是协议？

比如说我收到了一包数据，然后我去处理它。在我处理的同时呢，我又收到了两包数据。当我处理完手中的这一包数据再回过头来看我的缓存区，哎！我发现两包数据它们粘在一起了。那我应该怎么办呢？当然是要把它们拆开，而我拆开它们的依据就是——协议。

有的协议呢它是一个固定长度的，比如我们说有一种协议，它的数据包长度固定就是十个字节。也就是说每十个字节我都可以认为它是一个完整的数据包。
有的协议呢它也没有说固定是多长，它的长度是在数据包的第n位注明的。从数据包的头部开始读取，读到长度位，它告诉你后续还有20个字节。
还有的协议它是以一个固定的符号作为分割，比如说回车、换行符这种。我也不知道我前面有多长，但是一遇特定的结束符号就知道这一包数据结束了。

这就是协议的作用。

## 为什么要用解包器呢？

因为在发送数据和接收数据的过程中有可能会发生粘包和断包这两种情况。

## 什么是粘包呢？

就如上文所说的那样，我在处理一个数据包的时候，多个数据包堆叠在了缓存区中，这样就发生了粘包。

## 什么是断包呢？

断包是为什么呢？对于发送端的种种原因，他一句话没说完，他给你来个大喘气，只说了前半部分，但是你通过前半部分呢已经知道他的话还没有说完，你就在那耐心的等他，等他…这就是遇到了断包。
遇到断包你就需要把前半部分存起来，耐心的等后半部分消息传来把前后数据拼接完整才认为这是一个完整的数据包。然后再进行处理。

## 视频教程

<iframe id="dVWvoUmb-1655132321896" src="https://player.bilibili.com/player.html?aid=427343944" allowfullscreen="true" data-mediaembed="bilibili" style="box-sizing: border-box; outline: 0px; margin: 0px; padding: 0px; font-weight: normal; overflow-wrap: break-word; display: block; width: 730px; height: 365px;"></iframe>

【女朋友都能学会】C# 协议解包器(优雅处理粘包断包)

源代码
通信协议格式
教学视频中展示出的协议格式草图（群友小伙伴提供）：

针对此协议格式完成的数据包代码如下：

```c#
    /// <summary>
    /// 数据协议
    /// </summary>
    public class SimpleData : Response, IRequest
    {
        /// <summary>
        /// 协议起始标记
        /// </summary>
        public static readonly byte[] StartMark = new byte[] { 0xDD, 0xEE };

        /// <summary>
        /// 功能码
        /// </summary>
        public FunctionCode Code { get; }

        /// <summary>
        /// 方位角度
        /// </summary>
        public short Heading { get; }

        /// <summary>
        /// 俯仰角度
        /// </summary>
        public short Tilt { get; }

        public SimpleData(IEnumerable<byte> bytes) : base(bytes)
        {
            var data = bytes.ToArray();
            if (bytes.Count() != 8)
            {
                throw new ArgumentException("长度应为8位");
            }
            if (!bytes.StartWith(StartMark))
            {
                throw new ArgumentException("协议头错误");
            }
            if (CheckSum(bytes.Skip(2).Take(5)) != bytes.Last())
            {
                throw new ArgumentException("校验失败");
            }
            Code = (FunctionCode)data[2];
            Heading = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(data, 3));
            Tilt = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(data, 5));
        }

        public SimpleData(FunctionCode code, short heading, short tilt) : base(null)
        {
            Code = code;
            Heading = heading;
            Tilt = tilt;
        }

        public byte[] GetBytes()
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(StartMark);
            bytes.Add((byte)Code);
            bytes.AddRange(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(Heading)));
            bytes.AddRange(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(Tilt)));
            byte checkSum = CheckSum(bytes.Skip(2));
            bytes.Add(checkSum);
            return bytes.ToArray();
        }

        private byte CheckSum(IEnumerable<byte> bytes)
        {
            byte checksum = 0x00;
            foreach (byte bt in bytes)
            {
                checksum ^= bt;
            }
            return checksum;
        }

        /// <summary>
        /// 功能码
        /// </summary>
        public enum FunctionCode : byte
        {
            /// <summary>
            /// 停止
            /// </summary>
            Stop = 0,
            /// <summary>
            /// 定点
            /// </summary>
            FixedPoint = 1,
            /// <summary>
            /// 扇扫
            /// </summary>
            Scan = 2,
        }
    }
```
## 解包器的实现

由于协议草稿中展示的协议格式是一种非常简单的固定长度协议，所以在实现计算数据包长度的方法时只需要返回固定的8位即可。

```c#
    /// <summary>
    /// 固定长度的协议解包器
    /// 数据包长度固定，实现非常简单；
    /// 重写CalculatePacketLength方法时返回固定长度值即可
    /// </summary>
    public class SimpleDataUnpacker : Unpacker
    {
        public SimpleDataUnpacker()
        {
            StartMark = SimpleData.StartMark;
        }

        protected override int CalculatePacketLength(IEnumerable<byte> bytes) => 8;
    }
```
## 运行结果

模拟了断包和粘包数据的接收，在视频中可以看到运行结果。
![在这里插入图片描述](https://img-blog.csdnimg.cn/d97ce3d69d3441e1807a2e9d30b6c457.png)









# C# 优雅处理通信中的粘包和断包（二） 处理非固定长度的协议

## 前言

上篇文章中我们讲了一下固定长度的协议该怎么样使用解包器去解析，那今天我们再补充一点，就是非固定程度的协议该怎么样使用解包器去解析

------

## 分析协议格式我这里设计了一个协议，它长成这个样子：

我们来一起分析一下这个协议，协议头部这里设计的是a a b b。
第二部分是长度，也就是说到这一位往后还要接收多长的数据。
然后看数据长度占一个字节，假如数据位长度标记为n时，数据部分里有多少字节的数据呢？如果我们的这个长度里面的值是n的话，那数据位的长度就是n减1，最后一位是校验校验位占一个字节。

![在这里插入图片描述](https://img-blog.csdnimg.cn/e778badd18174284a1d437c5b0630519.png)

我们看第一个实例，AABB为起始头部。然后长度位里面标记着是7，也就是说从这一位往后，我还要接收7个字节的数据。
最后一位是我们的校验位，校验位校验的是从AABB起始位之后校验位之前的这一段数据；
下一个例子也是一样的，数据内如加校验位一共是4个字节，校验和计算的是从AABB起始位之后校验位之前这段数据的Checksum.

## 视频教程

<iframe id="DBI1er6K-1655220422906" src="https://player.bilibili.com/player.html?aid=427343944&amp;page=2" allowfullscreen="true" data-mediaembed="bilibili" style="box-sizing: border-box; outline: 0px; margin: 0px; padding: 0px; font-weight: 400; overflow-wrap: break-word; display: block; width: 730px; height: 365px; color: rgba(0, 0, 0, 0.75); font-family: -apple-system, &quot;SF UI Text&quot;, Arial, &quot;PingFang SC&quot;, &quot;Hiragino Sans GB&quot;, &quot;Microsoft YaHei&quot;, &quot;WenQuanYi Micro Hei&quot;, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: no-common-ligatures; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;"></iframe>

【女朋友都能学会】C# 协议解包器(优雅处理粘包断包)

## 源代码

让我们来看一下代码该怎么实现它。

在上一篇文章《解包器的基础用法》中实现的解包器它的协议是固定的八位长度，所以在计算包长度的时候就给了一个默认的八位，实现起来非常的简单。

我们今天再实现一个，按照上方这个协议去实现一个与之匹配的解包器。

    /// <summary>
    /// 非固定长度的协议解包器
    /// 数据包长度存放于数据包内指定位
    /// </summary>
    public class SimpleData2Unpacker : Unpacker
    {
        public SimpleData2Unpacker()
        {
            StartMark = new byte[] { 0xAA, 0xBB };
        }
    
        protected override int CalculatePacketLength(IEnumerable<byte> bytes)
        {
            if (bytes.Count() < 3)
            {
                return 0;
            }
            else
            {
                return bytes.ElementAt(2) + 3;
            }
        }
    }

我们需要重写这个计算包长度的方法，之前是固定的长度是个固定长度是八，我们现在是根据协议来计算它的长度的，就要重写一下这个方法。
我们至少需要知道几位才可以确定整个包的长度呢？至少要到第三位长度位才行。我们知道这位之后才知道它后面的内容有多长。
所以在计算包长度这个地方，如果无法判断总包长度的话可返回零。
如果断包它发生在数据长度位之前，比如只收到了两位数据，也就是AABB，那这个时候我们是没有办法判断整个包长度的，只有数据包的长度超过了这个第三位，那就可以知道这个数据包有多长。
因此编写判断条件的逻辑是：如果我拿到的这个数据的长度，它如果小于三的话呢，那我们就返回一个零就好，否则我们就要去找出这段数据里的第三位。
另外由于索引从零开始数的第三位，因此应该再加上前面的三位，那这样的话那我们就计算出来整个包的长度了，这就是非固定长度协议的解包器的配置方法



# C# 优雅处理通信中的粘包和断包（三） 处理使用结束符的协议

## 前言

之前我们已经讲过了两种常见的协议格式，分别是 `固定长度的协议` 和`非固定长度的协议`。
今天我们来讲第三种常见的协议格式——**`使用结束符的协议`**。

## 分析协议格式

看一下这个图，这个协议有什么特点呢？

![协议格式](https://img-blog.csdnimg.cn/32e180ed94db4c758e35bb18b31ee0d9.png)

它是由**协议头部**、**有效数据**、**校验码**、**协议尾部**构成。
与上一篇文章中所给出的那个协议不太一样，它并没有在数据包内注明当前数据包的总长度到底是多长，而是通过一个“头部”和一个“尾部”来进行匹配，从中截取数据包的有效的内容。

![示例数据](https://img-blog.csdnimg.cn/fbceb26db0b6407eab25e7f6e23d9d7e.png)

看两个示例，这里预设的协议头部是**AA BB**，协议尾部是**EE FF**。有效数据和校验位就在两者之间，看起来和上一篇文章中的协议格式有点相似，不同点在于数据包内部并没有用于注明长度的字节。
这种协议常用于明文字符串类型数据的通信，如AT指令等。

------

## 视频教程

<iframe id="fv1j1rMu-1655392145322" src="https://player.bilibili.com/player.html?aid=427343944&amp;page=3" allowfullscreen="true" data-mediaembed="bilibili" style="box-sizing: border-box; outline: 0px; margin: 0px; padding: 0px; font-weight: 400; overflow-wrap: break-word; display: block; width: 730px; height: 365px; color: rgba(0, 0, 0, 0.75); font-family: -apple-system, &quot;SF UI Text&quot;, Arial, &quot;PingFang SC&quot;, &quot;Hiragino Sans GB&quot;, &quot;Microsoft YaHei&quot;, &quot;WenQuanYi Micro Hei&quot;, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: no-common-ligatures; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;"></iframe>

【女朋友都能学会】C# 协议解包器(优雅处理粘包断包)

## 源代码

按照上方这个协议去实现与之匹配的解包器：

    /// <summary>
    /// 非固定长度的协议解包器
    /// 通过匹配特定的协议起始标记和结束标记来截取数据包
    /// </summary>
    public class SimpleData3Unpacker : Unpacker
    {
        private byte[] EndMark { get; } = new byte[] { 0xEE, 0xFF };
    
        public SimpleData3Unpacker()
        {
            StartMark = new byte[] { 0xAA, 0xBB };
        }
    
        protected override int CalculatePacketLength(IEnumerable<byte> bytes)
        {
            var index = bytes.IndexOf(EndMark);
            if (index < 0)
            {
                return 0;
            }
            else
            {
                return index + EndMark.Length;
            }
        }
    }

代码中在匹配协议尾部时使用了扩展方法`IndexOf`：

> var index = bytes.IndexOf(EndMark);

这是来自CodePuls扩展库的用于实现简单模式匹配（KMP算法）的扩展方法。通过NuGet即可安装，安装方法请参考文章：C# byte数组转十六进制字符串只需要一行代码

当然也可以手动实现简单的模式匹配算法来对协议尾部进行查找，KMP算法可以参考文章：C语言实现串的基本模式匹配

## 结束语

到此，BytesIO中**协议解包器**相关的基础部分已经完成了，在开发中遇到问题欢迎在评论区留言，也欢迎加入Q群中讨论。