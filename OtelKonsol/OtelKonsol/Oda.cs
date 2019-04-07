using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelKonsol
{
    
        abstract class Oda
        {
            private int odaNumaralari;
            private string yatakCesidi;
            private bool denizManzarasi = false;
            private bool havuzManzarasi = false;
            private bool ormanManzarasi = false;

            public abstract void RezervasyonYap(int odaNo, DateTime baslangic, DateTime bitis);
            public abstract void RezervasyonIptal();
            public string YatakCesidi
            {
                get { return yatakCesidi; }
                set { yatakCesidi = value; }
            }
            public int OdaNumarasi
            {
                get { return odaNumaralari; }
                set { odaNumaralari = value; }
            }
            public bool DenizManzarasi
            {
                get { return denizManzarasi; }
                set { denizManzarasi = value; }
            }
            public bool HavuzManzarasi
            {
                get { return havuzManzarasi; }
                set { havuzManzarasi = value; }
            }
            public bool OrmanManzarasi
            {
                get { return ormanManzarasi; }
                set { ormanManzarasi = value; }
            }

        }
    }

