using System;
using System.Net;
using System.Net.Mail;

namespace Mafly.Mail
{
    /// <summary>
    /// 发送邮件
    /// </summary>
    public class Mail : MailBase
    {
        private static MailConfig mailConfig;

        /// <summary>
        /// 初始化 Mafly.Mail 的空实例
        /// 默认读取程序运行目录的下的Config/MailSetting.config文件
        /// </summary>
        public Mail()
        {
            mailConfig = new MailConfig().Create();
        }

        /// <summary>
        /// 使用指定路径下的邮件配置信息文件
        /// </summary>
        /// <param name="path">包含邮件配置信息文件路径的 System.String。</param>
        public Mail(string path)
        {
            mailConfig = new MailConfig().Create(path);
        }

        /// <summary>
        /// 使用指定的 Mafly.Mail.Config 类对象初始化 Mafly.Mail 类的新实例。
        /// </summary>
        /// <param name="config">包含邮件配置信息的 Mafly.Mail.Config。</param>
        public Mail(MailConfig config)
        {
            mailConfig = config;
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="receiver">接收人邮箱</param>
        /// <param name="body">邮件内容</param>
        public void Send(string receiver, string body)
        {
            Send(new MailInfo { Receiver = receiver, ReceiverName = receiver, Body = body, Subject = body });
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="receiver">接收人邮箱</param>
        /// <param name="body">邮件内容</param>
        /// <param name="isSingleSend">是否群发单显</param>
        public void Send(string receiver, string body, bool isSingleSend)
        {
            Send(new MailInfo { Receiver = receiver, Body = body, Subject = body }, isSingleSend);
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="receiver">接收人邮箱</param>
        /// <param name="receiverName">接收人姓名</param>
        /// <param name="body">邮件内容</param>
        public void Send(string receiver, string receiverName, string body)
        {
            Send(new MailInfo { Receiver = receiver, ReceiverName = receiverName, Body = body, Subject = body });
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="receiver">接收人邮箱</param>
        /// <param name="receiverName">接收人姓名</param>
        /// <param name="subject">邮件主题</param>
        /// <param name="body">邮件内容</param>
        public void Send(string receiver, string receiverName, string subject, string body)
        {
            Send(new MailInfo { Receiver = receiver, ReceiverName = receiverName, Body = body, Subject = subject });
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="receiver">接收人邮箱</param>
        /// <param name="subject">邮件主题</param>
        /// <param name="body">邮件内容</param>
        /// <param name="isSingleSend">是否群发单显</param>
        public void Send(string receiver, string subject, string body, bool isSingleSend)
        {
            Send(new MailInfo { Receiver = receiver, Body = body, Subject = subject }, isSingleSend);
        }

        /// <summary>
        /// 发送邮件（带附件）
        /// </summary>
        /// <param name="info">接收人信息 Mafly.Mail.MailInfo </param>
        /// <param name="attachments">附件列表 System.Net.Mail.Attachment </param>
        public void Send(MailInfo info, params Attachment[] attachments)
        {
            var message = new MailMessage();
            foreach (var item in attachments)
            {
                message.Attachments.Add(item);
            }
            try
            {
                Send(info, message);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 发送邮件（带附件）
        /// </summary>
        /// <param name="info">接收人信息 Mafly.Mail.MailInfo </param>
        /// <param name="filePath">附件路径 System.String </param>
        public void Send(MailInfo info, string filePath)
        {
            var message = new MailMessage();
            message.Attachments.Add(new Attachment(filePath));
            Send(info, message);
        }

        /// <summary>
        /// 发送邮件（带附件）
        /// </summary>
        /// <param name="info">接收人信息 Mafly.Mail.MailInfo </param>
        /// <param name="filePath">附件路径 System.String </param>
        /// <param name="isSingleSend">是否群发单显</param>
        public void Send(MailInfo info, string filePath, bool isSingleSend)
        {
            var message = new MailMessage();
            message.Attachments.Add(new Attachment(filePath));
            Send(info, isSingleSend, message);
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="info">接收人信息 Mafly.Mail.MailInfo </param>
        /// <param name="message">默认为null。 System.Net.Mail.MailMessage </param>
        public void Send(MailInfo info, MailMessage message = null)
        {
            base.Send(info, mailConfig, message);
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="info">接收人信息 Mafly.Mail.MailInfo </param>
        /// <param name="isSingleSend">是否群发单显</param>
        /// <param name="message">默认为null。 System.Net.Mail.MailMessage </param>
        public void Send(MailInfo info, bool isSingleSend, MailMessage message = null)
        {
            base.Send(info, mailConfig, message, isSingleSend);
        }
    }
}
