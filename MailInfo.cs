namespace Mafly.Mail
{
    /// <summary>
    ///     发送邮件的信息
    /// </summary>
    public class MailInfo
    {
        /// <summary>
        /// 主题行
        /// </summary>
        private string _subject;

        /// <summary>
        /// 接收者名字
        /// </summary>
        public string ReceiverName { get; set; }

        /// <summary>
        /// 接收者邮箱（多个用英文“,”号分割）
        /// </summary>
        public string Receiver { get; set; }

        /// <summary>
        /// 邮件的主题行
        /// </summary>
        public string Subject
        {
            get
            {
                if (string.IsNullOrEmpty(_subject) && _subject.Length > 15)
                {
                    return Body.Substring(0, 15);
                }
                return _subject;
            }
            set { _subject = value; }
        }

        /// <summary>
        /// 正文内容
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 抄送人集合
        /// </summary>
        public string CC { get; set; }

        /// <summary>
        /// 回复地址
        /// </summary>
        public string Replay { get; set; }
    }
}