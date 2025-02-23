using System.Text.Json.Serialization;

namespace ETicaretAPI.Application.DTOs.Facebook
{
    public class FacebookAccessTokenResponse
    {
        [JsonPropertyName("access_token")]
        public string accessToken { get; set; }
        [JsonPropertyName("token_type")]
        public string tokenType { get; set; }
    }
}
