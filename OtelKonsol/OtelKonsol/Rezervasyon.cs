using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelKonsol
{
    class Rezervasyon : Otel
    {
        internal void RezervasyonYap(int isim, string tip, bool havuz, bool deniz, bool orman, Oda[] odalar, DateTime baslangic, DateTime bitis, string[,] takvim, int[,] kullanici)//dışarıdan girilenler
        {
            bool check = false;
            for (int i = 0; i < 36; i++)
            {
                if (havuz == true && odalar[i].HavuzManzarasi == true && tip == odalar[i].YatakCesidi)//dışardan girilen manzara ve oda tiplerine bakıyor
                {
                    check = TariheBak(isim, odalar, takvim, baslangic, bitis, i, kullanici);//odanın boşluğuna bakıyor
                    if (check)
                    {
                        Console.WriteLine(odalar[i].OdaNumarasi + " " + odalar[i].YatakCesidi);//onlara uygun odayı veriyo
                        break;
                    }
                }
                else if (deniz == true && odalar[i].DenizManzarasi == true && tip == odalar[i].YatakCesidi)//dışardan girilen manzara ve oda tiplerine bakıyor
                {
                    check = TariheBak(isim, odalar, takvim, baslangic, bitis, i, kullanici);
                    if (check)
                    {
                        Console.WriteLine(odalar[i].OdaNumarasi + " " + odalar[i].YatakCesidi);
                        break;
                    }
                }
                else if (orman == true && odalar[i].OrmanManzarasi == true && tip == odalar[i].YatakCesidi)//dışardan girilen manzara ve oda tiplerine bakıyor
                {
                    check = TariheBak(isim, odalar, takvim, baslangic, bitis, i, kullanici);
                    if (check)
                    {
                        Console.WriteLine(odalar[i].OdaNumarasi + " " + odalar[i].YatakCesidi);
                        break;
                    }
                }

            }
        }
        private bool TariheBak(int isim, Oda[] odalar, string[,] takvim, DateTime baslangic, DateTime bitis, int odaNo, int[,] kullanici)
        {
            int k = Convert.ToInt32(bitis.Day) - Convert.ToInt32(baslangic.Day);
            int k2 = 0;
            for (int j = baslangic.Day; j < bitis.Day; j++)//baslangıc ve bitis tarihinin düzgün olması
            {
                if (takvim[odaNo, j] == " - ")//eger oda boşsa
                {
                    k2++;
                    if (k2 == k)
                    {
                        for (int t = baslangic.Day; t < bitis.Day; t++)
                        {
                            takvim[odaNo, t] = " D ";//o odayı o tarihlerde doldur.

                            kullanici[odaNo, t] = isim;

                        }
                        return true;
                    }
                }
            }
            Console.WriteLine("o tarihlerde kritere uyan oda bulunamadı");
            return false;


        }
        public void OdaMusaitMi(Oda[] odalar, string[,] takvim)
        {
            for (int i = 0; i < 36; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    Console.Write(takvim[i, j]);// tahvimi gösterir

                }
                Console.WriteLine();
            }

        }

        public void RezervasyonIptal(Oda[] odalar, int[,] kullanici, string[,] takvim, int isim)
        {
            for (int i = 0; i < 36; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    if (isim == kullanici[i, j])
                        takvim[i, j] = " - ";// takvimde D olan kısımları "-" yapar.

                }
            }

        }
    }
}
