using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelKonsol
{
    class Otel
    {
        internal List<TekYatakliOda> tek { get; }
        internal List<IkizYatakliOda> ikiz { get; }
        internal List<CiftYatakliOda> cift { get; }


        public Otel()
        {
            //tek odalı
            this.tek = new List<TekYatakliOda>(12);
            for (int i = 0; i < tek.Capacity; i++)
            {
                tek.Add(new TekYatakliOda(100 + i));
                if (i >= 0 && i <= 3) tek[i].manzara("Orman");
                else if (i >= 4 && i <= 7) tek[i].manzara("Deniz");
                else if (i >= 8 && i <= 11) tek[i].manzara("Havuz");
            }

            //çift odalı
            this.cift = new List<CiftYatakliOda>(12);
            for (int i = 0; i < cift.Capacity; i++)
            {
                cift.Add(new CiftYatakliOda(200 + i));
                if (i >= 0 && i <= 3) cift[i].manzara("Orman");
                else if (i >= 4 && i <= 7) cift[i].manzara("Deniz");
                else if (i >= 8 && i <= 11) cift[i].manzara("Havuz");

            }
            //ikiz odalı
            this.ikiz = new List<IkizYatakliOda>(12);
            for (int i = 0; i < ikiz.Capacity; i++)
            {
                ikiz.Add(new IkizYatakliOda(300 + i));
                if (i >= 0 && i <= 3) ikiz[i].manzara("Orman");
                else if (i >= 4 && i <= 7) ikiz[i].manzara("Deniz");
                else if (i >= 8 && i <= 11) ikiz[i].manzara("Havuz");

            }

        }
        public void dolulukOranı()
        {
            Console.WriteLine("Bugun için doluluk orani");
            double sum = 0;
            double total = 0;
            for (int i = 0; i < tek.Count; i++)
            {
                if (tek[i].takvim[0].rezeverMi) sum++;

            }

            Console.WriteLine("Tekliler icin doluluk oranı = " + sum + "/" + 12 + "= > " + (sum / 12).ToString());


            total += sum;
            sum = 0;
            for (int i = 0; i < cift.Count; i++)
            {
                if (cift[i].takvim[0].rezeverMi) sum++;

            }

            Console.WriteLine("\nCiftliler icin doluluk oranı = " + sum + "/" + 12 + "= > " + (sum / 12).ToString());

            total += sum;
            sum = 0;
            for (int i = 0; i < ikiz.Count; i++)
            {
                if (ikiz[i].takvim[0].rezeverMi) sum++;

            }

            Console.WriteLine("\nIkizler icin doluluk oranı = " + sum + "/" + 12 + "= > " + (sum / 12).ToString());

            total += sum;

            Console.WriteLine("\nGenel doluluk oranı = " + total + "/" + 36 + "= > " + (total / 36).ToString());

        }






    }
}

