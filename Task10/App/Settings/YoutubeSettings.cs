using Microsoft.Extensions.Configuration;

namespace App.Settings
{
    public class YoutubeSettings
    {
        public string ApiKey;
        public string Url;
        private const string ApiString = "API_Key";
        private const string UrlString = "Url";

        public YoutubeSettings(IConfiguration configuration)
        {
            ApiKey = configuration.GetSection(ApiString).Value; 
            Url = configuration.GetSection(UrlString).Value; 
        }
    }
}
