using Newtonsoft.Json;
using Nexus.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Helpers
{
    public class JsonFileHelper
    {
        private static readonly string AppDataPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
            "NexusData");

        private static readonly string AccountFilePath = Path.Combine(AppDataPath, "account.json");

        public JsonFileHelper()
        {
            if (!Directory.Exists(AppDataPath))
            {
                Directory.CreateDirectory(AppDataPath);
            }

            if (!File.Exists(AccountFilePath))
            {
                CreateAccountJsonFile();
            }
        }

        private void CreateAccountJsonFile()
        {
            Account account = new Account()
            {
                DisplayUsername = string.Empty,
                DefaultToken = string.Empty,
                Tokens = new List<string>()
            };

            string jsonString = JsonConvert.SerializeObject(account, Formatting.Indented);
            File.WriteAllText(AccountFilePath, jsonString);
        }
    }
}
