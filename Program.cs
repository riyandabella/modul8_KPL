using System.Security.Cryptography.X509Certificates;
using modul8_103022300001;

internal class Program
{
    private static void Main(string[] args)
    {
        int banyakTransfer;
        int biayaTf;

        BankTransferConfig config = new BankTransferConfig();


        if (config.lang == "en")
        {

            Console.WriteLine("Please insert the amount of money to transfer:");
            banyakTransfer = Convert.ToInt32(Console.ReadLine());
        }
        else
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
            banyakTransfer = Convert.ToInt32(Console.ReadLine());
        }

        if (banyakTransfer < config.transfer.threshold)
        {
            Console.WriteLine(config.transfer.low_fee);
            biayaTf = config.transfer.low_fee;

        } else
        {
            Console.WriteLine(config.transfer.high_fee);
            biayaTf = config.transfer.high_fee;
        }

        if (config.lang == "en")
        {
            Console.WriteLine("Transfer fee = " + biayaTf);
            Console.WriteLine("Total amount = " + (banyakTransfer + biayaTf));
            Console.WriteLine("Select transfer method:");
        }
        else
        {
            Console.WriteLine("Biaya transfer = " + biayaTf);
            Console.WriteLine("Total biaya = " + (banyakTransfer + biayaTf));
            Console.WriteLine("Pilih metode transfer:");
        }


    }
}
