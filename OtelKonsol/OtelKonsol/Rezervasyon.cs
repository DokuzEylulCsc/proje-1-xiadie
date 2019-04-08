﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelKonsol
{
    class Rezervasyon
    {

        public static bool rezerve(Otel otel, string musteriTC, string odaTipi, string manzarası
            , DateTime start, DateTime end)
        {

            double price = 0;
            int sec = sorgu(otel, musteriTC, odaTipi, manzarası, start, end, true);
            if (sec < 0) return false;
            else
            {
                if (odaTipi.Equals("Tek Yatakli Oda"))
                    price = otel.tek[sec].rezervasyonYap(start, end, musteriTC);
                else if (odaTipi.Equals("Cift Yatakli Oda"))
                    price = otel.cift[sec].rezervasyonYap(start, end, musteriTC);
                else if (odaTipi.Equals("Ikiz Yatakli Oda"))
                    price = otel.ikiz[sec].rezervasyonYap(start, end, musteriTC);
                Console.WriteLine("Toplam ucret = " + price);
                return true;
            }

        }



        public static bool iptal(Otel otel, string musteriTC, string odaTipi, string manzarası
           , DateTime start, DateTime end)
        {


            int sec = sorgu(otel, musteriTC, odaTipi, manzarası, start, end, false);
            if (sec < 0) return false;
            else
            {
                if (odaTipi.Equals("Tek Yatakli Oda"))
                    otel.tek[sec].rezervasyonIptal(start, end, musteriTC);
                else if (odaTipi.Equals("Cift Yatakli Oda"))
                    otel.cift[sec].rezervasyonIptal(start, end, musteriTC);
                else if (odaTipi.Equals("Ikiz Yatakli Oda"))
                    otel.ikiz[sec].rezervasyonIptal(start, end, musteriTC);
                return true;
            }

        }

        // sorgu tipi ekleme ise true döner iptal ise false döner
        public static int sorgu(Otel otel, string musteriTC, string odaTipi, string manzarası
         , DateTime start, DateTime end, bool sorguTipi)
        {

            if (odaTipi.Equals("Tek Yatakli Oda"))
            {
                if (manzarası.Equals("Orman"))
                {
                    for (int i = 0; i <= 3; i++)
                    {
                        if (otel.tek[i].rezervasyonSorgu(start, end)) return i;
                        else if (!otel.tek[i].rezervasyonSorgu(start, end) && !sorguTipi)
                            return i;

                    }
                }
                else if (manzarası.Equals("Deniz"))
                {
                    for (int i = 4; i <= 7; i++)
                    {
                        if (otel.tek[i].rezervasyonSorgu(start, end)) return i;
                        else if (!otel.tek[i].rezervasyonSorgu(start, end) && !sorguTipi)
                            return i;


                    }

                }
                else if (manzarası.Equals("Havuz"))
                {
                    for (int i = 8; i <= 11; i++)
                    {
                        if (otel.tek[i].rezervasyonSorgu(start, end)) return i;
                        else if (!otel.tek[i].rezervasyonSorgu(start, end) && !sorguTipi)
                            return i;


                    }

                }


            }
            else if (odaTipi.Equals("Ikiz Yatakli Oda"))
            {
                if (manzarası.Equals("Orman"))
                {
                    for (int i = 0; i <= 3; i++)
                    {
                        if (otel.ikiz[i].rezervasyonSorgu(start, end)) return i;
                        else if (!otel.ikiz[i].rezervasyonSorgu(start, end) && !sorguTipi)
                            return i;


                    }
                }
                else if (manzarası.Equals("Deniz"))
                {
                    for (int i = 4; i <= 7; i++)
                    {
                        if (otel.ikiz[i].rezervasyonSorgu(start, end)) return i;
                        else if (!otel.ikiz[i].rezervasyonSorgu(start, end) && !sorguTipi)
                            return i;


                    }

                }
                else if (manzarası.Equals("Havuz"))
                {
                    for (int i = 8; i <= 11; i++)
                    {
                        if (otel.ikiz[i].rezervasyonSorgu(start, end)) return i;
                        else if (!otel.ikiz[i].rezervasyonSorgu(start, end) && !sorguTipi)
                            return i;


                    }

                }



            }
            else if (odaTipi.Equals("Cift Yatakli Oda"))
            {
                if (manzarası.Equals("Orman"))
                {
                    for (int i = 0; i <= 3; i++)
                    {
                        if (otel.cift[i].rezervasyonSorgu(start, end)) return i;
                        else if (!otel.cift[i].rezervasyonSorgu(start, end) && !sorguTipi)
                            return i;


                    }
                }
                else if (manzarası.Equals("Deniz"))
                {
                    for (int i = 4; i <= 7; i++)
                    {
                        if (otel.cift[i].rezervasyonSorgu(start, end)) return i;
                        else if (!otel.cift[i].rezervasyonSorgu(start, end) && !sorguTipi)
                            return i;


                    }

                }
                else if (manzarası.Equals("Havuz"))
                {
                    for (int i = 8; i <= 11; i++)
                    {
                        if (otel.cift[i].rezervasyonSorgu(start, end)) return i;
                        else if (!otel.cift[i].rezervasyonSorgu(start, end) && !sorguTipi)
                            return i;



                    }

                }


            }
            return -1;
        }






        public static void istatistikSorgu(Otel otel)  //İstatiksel Sorgu ile otelimizin doluluk oranına bakıyoruz.
        {
            otel.dolulukOranı();
        }
    }


}
