
using System.Collections.Generic;
namespace ZY.Mail
{
    /// <summary>
    /// 发送邮件的信息
    /// </summary>
    public class MailInfo
    {
        public string ReceiverName { get; set; }
        public string Receiver { get; set; }
        private string subject;
        public string Subject
        {
            get
            {
                if (string.IsNullOrEmpty(subject))
                {
                    return Body.Substring(0, 15);
                }
                return subject;
            }
            set
            {
                subject = value;
            }
        }
        public string Body { get; set; }
        public string CC { get; set; }
        public string Replay { get; set; }
    }
}
