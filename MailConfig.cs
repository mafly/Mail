using Newtonsoft.Json;
using System;

namespace ZY.Mail
{
    /// <summary>
    /// 邮件配置信息
    /// </summary>
    [JsonObject]
    public class MailConfig
    {
        private string path = string.Empty;
        public MailConfig Create()
        {
            try
            {
                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                path = basePath + "Config/MailSetting.config";
                using (System.IO.StreamReader sr = new System.IO.StreamReader(path))
                {
                    return JsonConvert.DeserializeObject<MailConfig>(sr.ReadToEnd());
                }
            }
            catch
            {
                return new MailConfig();
            }
        }
        public MailConfig Create(string configPath)
        {
            try
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(configPath))
                {
                    return JsonConvert.DeserializeObject<MailConfig>(sr.ReadToEnd());
                }
            }
            catch
            {
                return new MailConfig();
            }
        }
        [JsonProperty]
        public string Host { get; set; }
        [JsonProperty]
        public int Port { get; set; }
        [JsonProperty]
        public string User { get; set; }
        [JsonProperty]
        public string Password { get; set; }
        [JsonProperty]
        public bool IsHtml { get; set; }
        [JsonProperty]
        public string DisplayName { get; set; }
        [JsonProperty]
        public string From { get; set; }
        [JsonProperty]
        public bool EnableSsl { get; set; }
    }

}
