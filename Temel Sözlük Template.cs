using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, string> sozluk = new Dictionary<string, string>();

        // SozlukVeri.txt dosyasını açıp okuma işlemi yapılır.
        using (StreamReader sr = new StreamReader("SozlukVeri.txt"))
        {
            string line;
            string anahtar = "";
            string aciklama = "";
            while ((line = sr.ReadLine()) != null)
            {
                if (line.StartsWith("-s/"))
                {
                    anahtar = line.Substring(3);
                }
                else if (line.StartsWith("-a/"))
                {
                    aciklama = line.Substring(3);
                    sozluk.Add(anahtar, aciklama);
                }
            }
        }

        while (true)
        {
            Console.WriteLine("Aranacak kelimeyi girin (çıkmak için é):");
            string anahtarKelime = Console.ReadLine();

            if (anahtarKelime.ToLower() == "é")
            {
                break;
            }

            if (sozluk.ContainsKey(anahtarKelime))
            {
                Console.WriteLine($"{anahtarKelime}: {sozluk[anahtarKelime]}");
            }
            else
            {
                Console.WriteLine($"{anahtarKelime} sözlükte bulunamadı.");
            }
        }
    }
}
