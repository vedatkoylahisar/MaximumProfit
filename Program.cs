using System;
using System.Collections.Generic;

public class Model
{
    public double AlisFiyati { get; set; }
    public double SatisFiyati { get; set; }
    public DateTime Tarih { get; set; }
}

class Program
{
    static void Main()
    {
        List<Model> dovizKurlari = new List<Model>()
        {
            new Model { AlisFiyati = 13.58, SatisFiyati = 13.61, Tarih = new DateTime(2024, 5, 18) },
            new Model { AlisFiyati = 13.61, SatisFiyati = 13.67, Tarih = new DateTime(2024, 5, 19) },
            new Model { AlisFiyati = 26.64, SatisFiyati = 26.90, Tarih = new DateTime(2024, 5, 20) },
            new Model { AlisFiyati = 10.00, SatisFiyati = 10.57, Tarih = new DateTime(2024, 5, 21) },
            new Model { AlisFiyati = 11.57, SatisFiyati = 11.70, Tarih = new DateTime(2024, 5, 22) },
            new Model { AlisFiyati = 11.69, SatisFiyati = 11.74, Tarih = new DateTime(2024, 5, 23) },
            new Model { AlisFiyati = 11.80, SatisFiyati = 11.87, Tarih = new DateTime(2024, 5, 24) },
            new Model { AlisFiyati = 11.74, SatisFiyati = 11.88, Tarih = new DateTime(2024, 5, 25) },
            new Model { AlisFiyati = 11.77, SatisFiyati = 11.89, Tarih = new DateTime(2024, 5, 26) },
            new Model { AlisFiyati = 11.88, SatisFiyati = 12.00, Tarih = new DateTime(2024, 5, 27) },
            new Model { AlisFiyati = 12.80, SatisFiyati = 12.55, Tarih = new DateTime(2024, 5, 28) },
            new Model { AlisFiyati = 13.80, SatisFiyati = 13.00, Tarih = new DateTime(2024, 5, 29) },
            new Model { AlisFiyati = 14.00, SatisFiyati = 13.89, Tarih = new DateTime(2024, 5, 30) },
            new Model { AlisFiyati = 13.57, SatisFiyati = 13.59, Tarih = new DateTime(2024, 5, 31) },
            new Model { AlisFiyati = 13.60, SatisFiyati = 13.99, Tarih = new DateTime(2024, 6, 1) },
            new Model { AlisFiyati = 13.75, SatisFiyati = 14.00, Tarih = new DateTime(2024, 6, 2) },
            new Model { AlisFiyati = 13.67, SatisFiyati = 13.89, Tarih = new DateTime(2024, 6, 3) },
            new Model { AlisFiyati = 13.77, SatisFiyati = 13.79, Tarih = new DateTime(2024, 6, 4) },
            new Model { AlisFiyati = 14.00, SatisFiyati = 13.99, Tarih = new DateTime(2024, 6, 5) },
            new Model { AlisFiyati = 14.25, SatisFiyati = 14.33, Tarih = new DateTime(2024, 6, 6) },
            new Model { AlisFiyati = 14.30, SatisFiyati = 14.40, Tarih = new DateTime(2024, 6, 7) },
            new Model { AlisFiyati = 14.85, SatisFiyati = 15.00, Tarih = new DateTime(2024, 6, 8) },
            new Model { AlisFiyati = 15.07, SatisFiyati = 15.74, Tarih = new DateTime(2024, 6, 9) },
            new Model { AlisFiyati = 15.25, SatisFiyati = 15.47, Tarih = new DateTime(2024, 6, 10) },
            new Model { AlisFiyati = 14.87, SatisFiyati = 15.07, Tarih = new DateTime(2024, 6, 11) },
            new Model { AlisFiyati = 14.89, SatisFiyati = 14.97, Tarih = new DateTime(2024, 6, 12) },
            new Model { AlisFiyati = 15.08, SatisFiyati = 15.15, Tarih = new DateTime(2024, 6, 13) },
            new Model { AlisFiyati = 15.50, SatisFiyati = 15.65, Tarih = new DateTime(2024, 6, 14) },
            new Model { AlisFiyati = 19.25, SatisFiyati = 19.50, Tarih = new DateTime(2024, 6, 15) },
            new Model { AlisFiyati = 18.25, SatisFiyati = 18.34, Tarih = new DateTime(2024, 6, 16) }
        };

        var hesapla = new Hesapla(dovizKurlari);
        hesapla.MaxKarHesapla();
    }
}

class Hesapla
{
    private List<Model> dovizKurlariList;

    public Hesapla(List<Model> dovizKurlari)
    {
        dovizKurlariList = dovizKurlari;
    }

    public void MaxKarHesapla()
    {
        int n = dovizKurlariList.Count;
        if (n == 0) return;

        double minAlisFiyati = dovizKurlariList[0].AlisFiyati;
        DateTime minAlisTarihi = dovizKurlariList[0].Tarih;
        double maxKar = 0;
        DateTime alisTarihi = dovizKurlariList[0].Tarih;
        DateTime satisTarihi = dovizKurlariList[0].Tarih;

        for (int i = 1; i < n; i++)
        {
            if (dovizKurlariList[i].AlisFiyati < minAlisFiyati)
            {
                minAlisFiyati = dovizKurlariList[i].AlisFiyati;
                minAlisTarihi = dovizKurlariList[i].Tarih;
            }

            double kar = dovizKurlariList[i].SatisFiyati - minAlisFiyati;
            if (kar > maxKar)
            {
                maxKar = kar;
                alisTarihi = minAlisTarihi;
                satisTarihi = dovizKurlariList[i].Tarih;
            }
        }

        Console.WriteLine("Max kar: " + maxKar);
        Console.WriteLine("Alis tarihi: " + alisTarihi.ToString("yyyy-MM-dd"));
        Console.WriteLine("Satis tarihi: " + satisTarihi.ToString("yyyy-MM-dd"));
    }
}
