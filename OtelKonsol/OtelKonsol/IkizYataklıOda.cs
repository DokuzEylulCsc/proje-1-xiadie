using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelKonsol
{
    class IkizYataklıOda:Oda
    {
        public IkizYataklıOda(int no, string manzaraTip)
        {
            OdaNumarasi = no + 1;
            YatakCesidi = "Ikiz";
            if (manzaraTip == "Havuz")
                HavuzManzarasi = true;
            else if (manzaraTip == "Orman")
                OrmanManzarasi = true;
            else
                DenizManzarasi = true;

        }
        public override void RezervasyonYap(int odaNo, DateTime baslangic, DateTime bitis)
        {

        }
        public override void RezervasyonIptal()
        {

        }
    }
}
