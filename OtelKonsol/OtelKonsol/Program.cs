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
            Otel otel = new Otel();
            otel.OtelUygulama(otel);
            Console.ReadLine();

        }
    }
}
