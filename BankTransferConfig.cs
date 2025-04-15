using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class transfer {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }
}
public class confirmation {
        public string en { get; set; }
        public string id { get; set; }
}
        
public class BankTransferConfig
{
    public string lang { get; set; }
    public transfer transfer{ get; set; }
    public List<string> methods { get; set; }
    public confirmation confirmation { get; set; }

    private const string configPath = "bank_transfer_config.json";
    public BankTransferConfig config;

    public BankTransferConfig LoadFromFile()
    {
        String configJsonData = File.ReadAllText(configPath);
        config = JsonSerializer.Deserialize<BankTransferConfig>(configJsonData); 
        return config;
    }

    private void WriteNewConfigFile()
    {
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true
        };
        String jsonString = JsonSerializer.Serialize(config, options);
        File.WriteAllText(configPath, jsonString);
    }
    public void UbahLang()
    {
        lang = lang == "en" ? "id" : "en";
        WriteNewConfigFile();
    }
} 

