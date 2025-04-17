using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_103022300001
{
    class Transfer
    {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }

        public Transfer (int threshold, int low_fee, int high_fee)
        {
            this.threshold = threshold;
            this.low_fee = low_fee;
            this.high_fee = high_fee;
        }
    }

    class Confirmation
    {
        public String en { get; set; }
        public String id { get; set; }

        public Confirmation (String en, String id)
        {
            this.en = en;
            this.id = id;
        }
    }

    internal class BankTransferConfig
    {

        public String lang {  get; set; }
        public String[] methods { get; set; }
        public Transfer transfer {  get; set; }
        public  Confirmation confirmation { get; set; }

        public BankTransferConfig() { }
        public BankTransferConfig(string lang, string[] methods, Transfer transfer, Confirmation confirmation)
        {
            this.lang = lang;
            this.methods = methods;
            this.transfer = transfer;
            this.confirmation = confirmation;
        }

    }

    class UIConfig
    {
        public BankTransferConfig bankTransferConfig;
        public const String filePath = @"bank_transfer_config.json";

        private BankTransferConfig ReadConfigFile()
        {
            var json = File.ReadAllText(filePath);
            bankTransferConfig = JsonSerializer.Deserialize<BankTransferConfig>(json);
            return bankTransferConfig;
        }

        private void SetDefault ()
        {
            bankTransferConfig = new BankTransferConfig();
            bankTransferConfig.transfer = new Transfer(25000000, 6500, 15000);
            bankTransferConfig.confirmation = new Confirmation("yes", "ya");
            bankTransferConfig.lang = "en";
            bankTransferConfig.methods = ["RTO (real-time)", "SKN", "RTGS", "BI FAST"];
        }

        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            String jsonString = JsonSerializer.Serialize(bankTransferConfig, options);
            File.WriteAllText(filePath, jsonString);
        }

        public UIConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }
    }
}
