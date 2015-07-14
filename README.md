# 一行代码，发送邮件
====

由于几乎在项目开发中离不开发送邮件功能，所以，我们反感反复造轮子，就基于Net.Mail封装的发送邮件代码。可以用于在.Net项目中发送邮件，只需一行代码，真的是一行。支持多附件、多接收人、多抄送人。

>  注：欢迎大家使用及提Bug.

---

## 特性

* 支持自定义邮件发出邮箱、发出方名字等。
* 支持SSL加密发送。
* 多个接收人、抄送人。
* 支持添加附件、多个附件。
* 目前大部分主流邮箱全支持。

## 安装

via NuGet:

```bash
1.打开程序包管理器控制台，执行命令：
  Install-Package Mafly.Mail
或：
2.在Project右键，选择“管理NuGet程序包”，在右上角搜索框搜索“Mafly.Mail”。点击安装
```

via 源代码:

```bash
引用如下两个 .dll 文件
  Newtonsoft.Json.dll
  Mafly.Mail.dll
然后在项目目录下建立一个名字为 Config 文件夹，放入 MailSetting.config 文件，根据自己的邮箱服务器进行配置
```
>  注：以上两种方式完成后，都要把`MailSetting.config`的`复制到输出目录`设置为`始终复制`，或者把`生成操作`设置为`嵌入的资源`。
>       这一步不能少！不能少！！不能少！！！

## 用法

```C#
          var mailService = new Mafly.Mail.Mail();

          //参数：接收者邮箱、内容
          mailService.Send("mafly@obo2o.cn", "测试邮件发送！");

          //参数：接收者邮箱、接收者名字、内容
          mailService.Send("mafly@obo2o.cn", "mafly", "测试邮件发送！");

          //参数：接收者邮箱、接收者名字、邮件主题、内容
          mailService.Send("mafly@obo2o.cn", "mafly", "邮件发送", "测试邮件发送！");

          //使用MailInfo对象模式  参数：接收者邮箱、接收者名字、邮件主题、内容
          mailService.Send(new MailInfo
          {
              Receiver = "mafly@obo2o.cn",
              ReceiverName = "mafly",
              Subject = "邮件发送",
              Body = "测试邮件发送！"
          });

          //使用MailInfo对象模式  参数：接收者邮箱、接收者名字、邮件主题、内容、附件路径
          mailService.Send(
              new MailInfo
              {
                   Receiver = "mafly@obo2o.cn",
                  ReceiverName = "mafly",
                  Subject = "带附件邮件发送",
                   Body = "测试带附件邮件发送！"
              }, "../../Program.cs");

          //使用MailInfo对象模式  参数：接收者邮箱、接收者名字、邮件主题、内容、多附件路径
          mailService.Send(
              new MailInfo
              {
                Receiver = "mafly@obo2o.cn",
                  ReceiverName = "mafly",
                  Subject = "带附件邮件发送",
                  Body = "测试带附件邮件发送！"
              }, new Attachment("../../Program.cs"), new Attachment("../../App.config"));
```

命令行：

```bash
$ pinyin 中心
zhōng xīn
$ pinyin -h
```

## API

### 方法 `<void> Send(参数...)`

该项目对外只有一个`Send(...)`公开方法，但该方法包含6个重载。几乎可以满足您的全部日常开发需求！


### 参数 `<sting> receiver`

接收人邮箱地址，支持多个email地址。
如需多个接收人请用英文逗号`,`进行分隔。

### 参数 `<string> receiverName`

接收人名字，可不填写，默认为null。

### 参数 `<string> body`

邮件内容。可以是纯文本，也可以包含 html 代码。

### 参数 `<sting> subject`

邮件主题，可不填写，默认为取邮件内容的前15个字符。

### 参数 `<string> filePath`

附件路径。发送带附件的邮件时，请填写要发送附件相对于程序运行目录的路径。

### 参数 `<object> MailInfo`

邮件信息对象。其中包含以下属性：
* `Receiver` 接收者邮箱（多个用英文“,”号分割）
* `ReceiverName` 接收者名字
* `Subject` 邮件的主题
* `Body` 正文内容
* `CC` 抄送人集合（多个用英文“,”号分割）
* `Replay` 回复地址

### 参数 `<object> Attachment`

附件对象。支持多个！具体请点击官方文档：[Attachment Class](https://msdn.microsoft.com/en-us/library/system.net.mail.attachment(v=vs.110).aspx)


### 参数 `<object> MailMessage`

邮件信息对象。具体请点击官方文档：[MailMessage Class](https://msdn.microsoft.com/en-us/library/system.net.mail.mailmessage(v=vs.110).aspx)


## Q&A

### 你封装的这一个其实并没有什么卵用，很简单阿，有这个必要吗？

是的，你说的对。


### 为什么不使用现成的那些、在线服务呢？如：SendCloud

你管。

### 真的是一行代码么？我看到好多行阿。

现在这个社会，没有噱头谁会看呢，您说是吧？

### 我能再问最后一个问题吗？

不能。

