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
    }

}
