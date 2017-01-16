using System.Net.Mail;
using Mafly.Mail;

namespace Mail.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var mailService = new Mafly.Mail.Mail();

            //群发单显参数：多接收者邮箱、内容
            mailService.Send("kanwolian@gmail.com,546601728@qq.com", "测试【群发单显】邮件发送！", true);

            //参数：接收者邮箱、内容
            //mailService.Send("kanwolian@gmail.com,546601728@qq.com", "测试邮件发送！");

            ////参数：接收者邮箱、接收者名字、内容
            //mailService.Send("nuget@mayongfa.cn", "mafly", "测试邮件发送！");

            ////参数：接收者邮箱、接收者名字、邮件主题、内容
            //mailService.Send("nuget@mayongfa.cn", "mafly", "邮件发送", "测试邮件发送！");

            ////使用MailInfo对象模式  参数：接收者邮箱、接收者名字、邮件主题、内容
            //mailService.Send(new MailInfo
            //{
            //    Receiver = "nuget@mayongfa.cn",
            //    ReceiverName = "mafly",
            //    Subject = "邮件发送",
            //    Body = "测试邮件发送！"
            //});

            ////使用MailInfo对象模式  参数：接收者邮箱、接收者名字、邮件主题、内容、附件路径
            //mailService.Send(
            //    new MailInfo
            //    {
            //        Receiver = "nuget@mayongfa.cn",
            //        ReceiverName = "mafly",
            //        Subject = "带附件邮件发送",
            //        Body = "测试带附件邮件发送！"
            //    }, "../../Program.cs");

            ////使用MailInfo对象模式  参数：接收者邮箱、接收者名字、邮件主题、内容、多附件路径
            //mailService.Send(
            //    new MailInfo
            //    {
            //        Receiver = "nuget@mayongfa.cn",
            //        ReceiverName = "mafly",
            //        Subject = "带附件邮件发送",
            //        Body = "测试带附件邮件发送！"
            //    }, new Attachment("../../Program.cs"), new Attachment("../../App.config"));

            System.Console.ReadKey();
        }
    }
}
