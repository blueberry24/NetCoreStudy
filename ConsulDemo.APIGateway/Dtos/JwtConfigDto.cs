using Newtonsoft.Json;

namespace ConsulDemo.APIGateway.Dtos
{
    public class JwtConfigDto
    {
        /// <summary>
        /// 密钥
        /// </summary>
        [JsonProperty("Secret")]
        public string Secret { get; set; }
        /// <summary>
        /// 颁发者
        /// </summary>
        [JsonProperty("Issuer")]
        public string Issuer { get; set; }
        /// <summary>
        /// 订阅者
        /// </summary>
        [JsonProperty("Audience")]
        public string Audience { get; set; }
        /// <summary>
        /// 令牌有效期（分钟）
        /// </summary>
        [JsonProperty("AccessExpiration")]
        public int AccessExpiration { get; set; }
        /// <summary>
        /// 刷新令牌有效期（分钟）
        /// </summary>
        [JsonProperty("RefreshExpiration")]
        public int RefreshExpiration { get; set; }
        /// <summary>
        /// 令牌失效缓冲时间（秒）
        /// </summary>
        [JsonProperty("SkewTime")]
        public int SkewTime { get; set; }
    }
}
