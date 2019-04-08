using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelKonsol
{
    class Program
    {

        static void Main(string[] args)
        {
            //yyyy:mm:dd

            DateTime start;
            DateTime end;

            Otel otel = new Otel();
            //end = start.AddDays(0); // üzerine 3 gün saydım
            while (!false)
            {
                Console.WriteLine("XİADİE OTEL");
                Console.WriteLine("1->Rezervasyon Seçimi  2->Rezervasyon İptal  3->İstatistik Sorgu  0->Çıkış");
                int choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("İstenilen tüm bilgileri istenilen formatta giriniz");
                            Console.WriteLine("Isim gir: ");
                            string name = Console.ReadLine();

                            Console.WriteLine("oda tipi giriniz: Tek Yatakli Oda - Cift Yatakli Oda - Ikiz Yatakli Oda");
                            string tipi = Console.ReadLine();//Yatak Tipi Seçimi

                            Console.WriteLine("manzara giriniz: Havuz - Orman - Deniz");
                            string manzarası = Console.ReadLine();//Manzara Seçimi

                            Console.WriteLine("Baslangıc Tarihi gir: Format ->> YYYY-MM-DD");
                            string tarih = Console.ReadLine();//Otele girilmek istenen tarih
                            start = DateTime.Parse(tarih);

                            Console.WriteLine("Kac gun kalacaksiniz");//Otelde bulunulacak süre
                            int kacgun = Int32.Parse(Console.ReadLine());
                            end = start.AddDays(kacgun);//bitiş için

                            if (Rezervasyon.rezerve(otel, name, tipi, manzarası, start, end))
                                Console.WriteLine("REZERVASYON YAPILDI");

                            else
                                Console.WriteLine("Rezervasyon yapılamadı");//yanlış giriş yapıldıgında
                            break;
                        }
                    case 2://Rezervasyonu iptal etmek için rezervasyon yapılan bilgiler girilip iptal oluyor
                        {
                            Console.WriteLine("Isim gir: ");
                            string name = Console.ReadLine();

                            Console.WriteLine("oda tipi giriniz: Tek Yatakli Oda - Cift Yatakli Oda - Ikiz Yatakli Oda");
                            string tipi = Console.ReadLine();

                            Console.WriteLine("manzara giriniz: Havuz - Orman - Deniz");
                            string manzarası = Console.ReadLine();

                            Console.WriteLine("Baslangıc Tarihi gir: Format ->> YYYY-MM-DD");
                            string tarih = Console.ReadLine();
                            start = DateTime.Parse(tarih);

                            Console.WriteLine("Kac gun kalmıstınız");
                            int kacgun = Int32.Parse(Console.ReadLine());
                            end = start.AddDays(kacgun);

                            if (Rezervasyon.iptal(otel, name, tipi, manzarası, start, end))
                                Console.WriteLine("REZEVRVASYON IPTALI BASARILI");

                            else
                                Console.WriteLine("Rezervasyon iptali başarısız");
                            break;
                        }

                    case 3:
                        {
                            Rezervasyon.istatistikSorgu(otel);//Otelin bugünlük sorgusu
                            break;
                        }
                    case 0:
                        {
                            return;

                        }


                }
            }
        }
    }
}
