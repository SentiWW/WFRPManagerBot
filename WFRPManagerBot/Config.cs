using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WFRPManagerBot
{
    class Config
    {
        private const string configFolder = "Resources";
        private const string configFile = "/config.xml";
        private const string path = configFolder + configFile;

        public static BotConfig bot;

        static Config()
        {
            if (!Directory.Exists(configFolder)) Directory.CreateDirectory(configFolder);

            if (!File.Exists(path))
            {
                bot = new BotConfig();

                var xmlSerializer = new XmlSerializer(typeof(BotConfig));
                var file = File.Create(path);
                xmlSerializer.Serialize(file, bot);
                file.Close();
            }
            else
            {
                var xmlSerializer = new XmlSerializer(typeof(BotConfig));
                using(Stream reader = new FileStream(path, FileMode.Open))
                {
                    bot = (BotConfig)xmlSerializer.Deserialize(reader);
                }
            }
        }
    }

    public class BotConfig
    {
        public string token = "YourToken";
        public string cmdPrefix = "YourCommandPrefix";
    }
}
