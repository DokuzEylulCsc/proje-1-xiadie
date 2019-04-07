using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelKonsol
{
    class TekYatakliOda:Oda
    {
        public TekYatakliOda(int no, string manzaraTip)
        {
            OdaNumarasi = no + 1;
            YatakCesidi = "Tek";
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
