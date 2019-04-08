using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelKonsol
{
    class Otel
    {
        Oda[] odalar = new Oda[36]; //Oda tipinde odalar dizisi.
        string[,] takvim = new string[36, 60];//36 oda için 60 günlük takvim oluşturduk
        int[,] kullanici = new int[36, 60];//kullanıcının seceği
        DateTime baslangic1 = DateTime.Today;//baslangıc tarihi
        DateTime bitis1 = DateTime.Today;//bitis tarihi

        public Otel()//Constructor Methodum
        {
            for (int i = 0; i < 12; i++)//ikiz yataklı odalar için 12 oda ayrıldı 4ü Havuz 4ü Deniz 4ü Orman manzaralı
            {
                if (i < 4)
                    odalar[i] = new IkizYatakliOda(100 + i, "Havuz");
                else if (i < 8)
                    odalar[i] = new IkizYatakliOda(100 + i, "Orman");
                else
                    odalar[i] = new IkizYatakliOda(100 + i, "Dag");
            }
            for (int i = 0; i + 12 < 24; i++)//Çift yataklı odalar için 12 oda ayrıldı 4ü Havuz 4ü Deniz 4ü Orman manzaralı
            {
                if (i < 4)
                    odalar[i + 12] = new CiftYatakliOda(200 + i, "Havuz");
                else if (i < 8)
                    odalar[i + 12] = new CiftYatakliOda(200 + i, "Orman");
                else
                    odalar[i + 12] = new CiftYatakliOda(200 + i, "Dag");
            }
            for (int i = 0; i + 24 < 36; i++)//tek  yataklı odalar için 12 oda ayrıldı 4ü Havuz 4ü Deniz 4ü Orman manzaralı
            {
                if (i < 4)
                    odalar[i + 24] = new TekYatakliOda(300 + i, "Havuz");
                else if (i < 8)
                    odalar[i + 24] = new TekYatakliOda(300 + i, "Orman");
                else
                    odalar[i + 24] = new TekYatakliOda(300 + i, "Dag");
            }


            Takvim();
        }


        public void OtelUygulama(Otel otel)
        {

            bool dogrulama = false;
            int secim = 0;
            do
            {
                try
                {

                    Console.WriteLine("Oda sorgu icin 1 - rezervasyon icin 2 - rezervasyon iptal icin 3 - cikmak icin baska sayi giriniz");
                    secim = int.Parse(Console.ReadLine());
                    switch (secim)
                    {
                        case 1: { otel.OdaMusaitlik(otel); dogrulama = false; break; }
                        case 2: { otel.RezervasyonYap(otel); dogrulama = false; break; }
                        case 3: { otel.RezervasyonIptal(otel, takvim); dogrulama = false; break; }
                        default: { Environment.Exit(0); break; }
                    }

                }
                catch (Exception)
                {
                    dogrulama = true;
                    Console.WriteLine("Hatali giris");
                }
            } while (dogrulama);

        }
        private void OdaMusaitlik(Otel otel)
        {
            Rezervasyon rezervasyon = new Rezervasyon();
            rezervasyon.OdaMusaitMi(odalar, takvim);//takvime bakıp odaların müsait olduğu yerleri gösteriyor

            otel.OtelUygulama(otel);

        }

        public void RezervasyonYap(Otel otel)
        {
            int hata = 1;//do while döngüsünü çıkmaza sokmak için oluşturduk
            string secim, tip = "";//seçilecek oda
            int isim = 0;
            bool havuzManzara = false, denizManzara = false, ormanManzara = false;// en başta hepsini seçilmemiş olarak alıyoruz

            do
            {
                hata = 0;
                try
                {
                    Console.WriteLine("kimlik no giriniz");
                    isim = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("baslangic tarihini giriniz (gg/aa/yyyy)");
                    string baslangicTarih = Console.ReadLine();
                    baslangic1 = Convert.ToDateTime(baslangicTarih);//belirlenen tarihler arasında başlangıç tarihini alıyor ve başlangıç1e kaydediyor
                    if (baslangic1 < DateTime.Today)
                        throw new Exception();        //tarihi küçük girince hata verdirmesini sağlamak için throwla catch e yakalatıyoruz

                    Console.WriteLine("bitis tarihini giriniz (gg/aa/yyyy)");
                    string bitisTarih = Console.ReadLine();
                    bitis1 = Convert.ToDateTime(bitisTarih);
                    if (bitis1 < DateTime.Today)
                        throw new Exception();
                    if (bitis1 < baslangic1)
                        throw new Exception();
                }
                catch (FormatException)// tarih haricinde birsey yazılırsa zaman yakalayıp hata veriyor.
                {
                    Console.WriteLine("yanlis format girdiniz");
                    hata = 1;
                }
                catch (Exception)
                {
                    Console.WriteLine("hatali tarih girdiniz");//tarih zaman aralığından farklı girerse yakalayıp hata veriyor.
                    hata = 1;
                }
            } while (hata == 1);
            do
            {
                hata = 0;

                Console.WriteLine("Yatak tipini seciniz (1 tek - 2 cift - 3 ikiz)");//if'in içinde yatak tiplerine girilmesi gereken sayıları belirtiyor.
                tip = Console.ReadLine();
                if (tip == "1")
                    hata = 0;
                else if (tip == "2")
                    hata = 0;
                else if (tip == "3")
                    hata = 0;
                else
                {
                    hata = 1;//eger başka bir sayı girerse hata veriyor
                    Console.WriteLine("hatali giris");
                }


            } while (hata == 1);


            switch (tip)//switch case yapısı kullanarak yatak çeşidi seçimi yaptık.
            {
                case "1": tip = "Tek"; break;
                case "2": tip = "Cift"; break;
                case "3": tip = "Ikiz"; break;
                default: Console.WriteLine("hatali giris"); break;
            }
            Console.WriteLine("Havuz manzarasi var mi(varsa 1 - yoksa 0)");
            secim = Console.ReadLine();
            if (secim == "1")//secim 1 yapılırsa havuz manzaralı odalara girer
            {
                havuzManzara = true;
            }
            else
            {
                havuzManzara = false;
                Console.WriteLine("Deniz manzarasi var mi(varsa 1 - yoksa 0)");//havuz manzaralı oda secilmezse deniz manzaralı için sorar
                secim = Console.ReadLine();
                if (secim == "1")
                {
                    denizManzara = true;
                }
                else
                {
                    Console.WriteLine("Orman manzarasi var mi(varsa 1 - yoksa 0)");//deniz manzarasıda secilmezse oda manzarası için sorar
                    secim = Console.ReadLine();
                    if (secim == "1")
                        ormanManzara = true;
                }

            }
            Rezervasyon rezervasyon = new Rezervasyon();
            rezervasyon.RezervasyonYap(isim, tip, havuzManzara, denizManzara, ormanManzara, odalar, baslangic1, bitis1, takvim, kullanici);
            otel.OtelUygulama(otel);

        }
        private void RezervasyonIptal(Otel otel, string[,] takvim)
        {
            Rezervasyon rezervasyon = new Rezervasyon();
            Console.WriteLine("kullanici adi giriniz");
            int isim = Convert.ToInt32(Console.ReadLine());
            rezervasyon.RezervasyonIptal(odalar, kullanici, takvim, isim);
            otel.OtelUygulama(otel);
        }
        private void Takvim()
        {
            for (int i = 0; i < 36; i++)//36 oda için
            {
                for (int j = 0; j < 60; j++)//60 gün
                {
                    if (j == 0)
                        takvim[i, j] = Convert.ToString(odalar[i].OdaNumarasi);
                    else
                        takvim[i, j] = " - ";//bos olan günler
                }
            }
        }
    }
}

