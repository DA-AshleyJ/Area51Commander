using Newtonsoft.Json;
using Area51Commander.Entities;
using System.IO;

namespace Area51Commander.Services
{
    public class ConfigService
    {
        public Config GetConfig()
        {
            var file = "Config.json";
            var data = File.ReadAllText(file);
            return JsonConvert.DeserializeObject<Config>(data);
        }
    }
}
