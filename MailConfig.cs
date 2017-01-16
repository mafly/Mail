using Newtonsoft.Json;
using System;

namespace Mafly.Mail
{
    /// <summary>
    /// 邮件配置信息
    /// </summary>
    [JsonObject]
    public class MailConfig
    {
        private string _path = string.Empty;

        /// <summary>
        /// 读取默认路径（Config/MailSetting.config）下的配置文件
        /// </summary>
        /// <returns></returns>
        public MailConfig Create()
        {
            try
            {
                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                _path = basePath + "Config/MailSetting.config";
                using (var sr = new System.IO.StreamReader(_path))
                {
                    return JsonConvert.DeserializeObject<MailConfig>(sr.ReadToEnd());
                }
            }
            catch
            {
                return new MailConfig();
            }
        }

        /// <summary>
        /// 读取改路径下的配置文件
        /// </summary>
        /// <param name="configPath">配置文件路径</param>
        /// <returns></returns>
        public MailConfig Create(string configPath)
        {
            try
            {
                using (var sr = new System.IO.StreamReader(configPath))
                {
                    return JsonConvert.DeserializeObject<MailConfig>(sr.ReadToEnd());
                }
            }
            catch
            {
                return new MailConfig();
            }
        }

        /// <summary>
        /// 主机名 如：smtp.163.com
        /// </summary>
        [JsonProperty]
        public string Host { get; set; }

        /// <summary>
        /// 端口号 如：25
        /// </summary>
        [JsonProperty]
        public int Port { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [JsonProperty]
        public string User { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [JsonProperty]
        public string Password { get; set; }

        /// <summary>
        /// 是否包含Html代码
        /// </summary>
        [JsonProperty]
        public bool IsHtml { get; set; }

        /// <summary>
        /// 发送者显示名
        /// </summary>
        [JsonProperty]
        public string DisplayName { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        [JsonProperty]
        public string From { get; set; }

        /// <summary>
        /// 是否启用SSL 默认：false 
        /// 如果启用 端口号要改为加密方式发送的
        /// </summary>
        [JsonProperty]
        public bool EnableSsl { get; set; }
    }

}
