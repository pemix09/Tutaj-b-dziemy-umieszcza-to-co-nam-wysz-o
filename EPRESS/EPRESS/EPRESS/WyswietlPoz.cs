using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPRESS
{
    class WyswietlPoz
    {
        public static void wysAutorow()
        {
            Console.Clear();
            DzialProgramowy.autorzy.Wypisz();
        }
        public static void wysUmowy()
        {
            Console.Clear();
            DzialProgramowy.umowy.Wypisz();
        }
        public static void wysKsiazki()
        {
            Console.Clear();
            DzialHandlowy.ksiazki.Wypisz();
        }
        public static void wysCzasopisma()
        {
            Console.Clear();
            DzialHandlowy.czasopisma.Wypisz();
        }
    }
}
