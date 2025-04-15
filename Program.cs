class Program
{
    static void Main(string[] args)
    {
        BankTransferConfig data = new BankTransferConfig();
        BankTransferConfig config = data.LoadFromFile();
        config.UbahLang();
        double biaya;

        if (config.lang == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer: ");
        }
        else if (config.lang == "id")
        {
             Console.WriteLine("Masukkan jumlah uang yang akan di-transfer: ");
        }
        double jumlah = Convert.ToDouble(Console.ReadLine());

        if (jumlah <= config.transfer.threshold)
        {
            biaya = Convert.ToDouble(config.transfer.low_fee);
        }
        else
        {
            biaya = Convert.ToDouble(config.transfer.high_fee);
        }

        double total = jumlah + biaya;

        if (config.lang == "en")
        {
            Console.WriteLine("Transfer fee = " + biaya);
            Console.WriteLine("Total amount = " + total);

            Console.WriteLine("\nSelect transfer method:");
        }
        else if (config.lang == "id")
        {
            Console.WriteLine("Biaya transfer =  " + biaya);
            Console.WriteLine("Total biaya = " + total);

            Console.WriteLine("\nPilih metode transfer:");
        }

        for (int i = 0; i < config.methods.Count; i++)
        {
            Console.WriteLine($" {config.methods[i]}");
        }
        string metode = Console.ReadLine();

        if (config.lang == "en")
        {
            Console.WriteLine($"Please type {config.confirmation.en} to confirm the transaction:");
            string confirm = Console.ReadLine();
            if (confirm == config.confirmation.en)
            {
                Console.WriteLine("The transfer is completed");
            }
            else
            {
                Console.WriteLine("Transfer is cancelled");
            }
        }
        else if (config.lang == "id")
        {
            Console.WriteLine($"Ketik {config.confirmation.id}  untuk mengkonfirmasi transaksi:");
            string confirm = Console.ReadLine();
            if (confirm == config.confirmation.id)
            {
                Console.WriteLine("Proses transfer berhasil");
            }
            else
            {
                Console.WriteLine("Transfer dibatalkan");
            }
        }
    }
}