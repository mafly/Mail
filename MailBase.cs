using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Mafly.Mail
{
    public class MailBase
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="info">接收人信息 Mafly.Mail.MailInfo </param>
        /// <param name="mailConfig">发件邮箱配置</param>
        /// <param name="message">默认为null。 System.Net.Mail.MailMessage </param>
        /// <param name="isSingleSend">是否群发单显。当邮件接收人为多个时，可选择该模式，即可对多个收件人分别发送，收件方不会知道这封邮件有多个收件人</param>
        protected void Send(MailInfo info, MailConfig mailConfig, MailMessage message = null, bool isSingleSend = false)
        {
            message = message ?? new MailMessage();
            message.Subject = info.Subject;
            if (!string.IsNullOrEmpty(info.Replay))
                message.ReplyToList.Add(new MailAddress(info.Replay));
            message.Body = info.Body;
            if (!string.IsNullOrEmpty(info.CC))
                message.CC.Add(info.CC);

            //群发单显（当邮件接收人为多个时，可选择该模式，即可对多个收件人分别发送，收件方不会知道这封邮件有多个收件人）
            if (isSingleSend && info.Receiver.Contains(","))
            {
                foreach (var item in info.Receiver.Split(','))
                {
                    message.To.Clear();
                    message.To.Add(item);

                    SmtpClientSend(mailConfig, message);
                }
                return;
            }
            else
            {
                if (!isSingleSend && info.Receiver.Contains(","))
                    message.To.Add(info.Receiver);
                else
                    message.To.Add(new MailAddress(info.Receiver, string.IsNullOrEmpty(info.ReceiverName) ? info.Receiver : info.ReceiverName));
            }

            SmtpClientSend(mailConfig, message);
        }

        private void SmtpClientSend(MailConfig mailConfig, MailMessage message)
        {
            var sender = new SmtpClient();
            sender.UseDefaultCredentials = false;
            sender.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                message.IsBodyHtml = mailConfig.IsHtml;
                message.From = new MailAddress(mailConfig.From, mailConfig.DisplayName);
                sender.Host = mailConfig.Host;
                sender.Port = mailConfig.Port;
                sender.Credentials = new NetworkCredential(mailConfig.User, mailConfig.Password);
                sender.EnableSsl = mailConfig.EnableSsl;
                sender.Send(message);
            }
            catch
            {
                //发送异常一般为发送邮箱配置有误，这里提供一个默认发件邮箱。
                message.From = new MailAddress("NuGets@163.com", "Mafly");
                message.IsBodyHtml = true;
                sender.Host = "smtp.163.com";
                sender.Port = 25;
                sender.Credentials = new NetworkCredential("NuGets@163.com", "vzihlbquwnriqlht");
                sender.EnableSsl = false;
                sender.Send(message);
            }
        }
    }
}
