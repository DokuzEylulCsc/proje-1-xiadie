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
    }
}
