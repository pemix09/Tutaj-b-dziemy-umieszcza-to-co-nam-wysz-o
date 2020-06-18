using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPRESS
{
    class UsunPoz
    {
        public static void usunAutora()
        {
            Autor autor;
            string imie, nazwisko;
            Console.Clear();
            if (DzialProgramowy.autorzy.Licz() == 0)
            {
                Console.WriteLine("Brak autorow w bazie.\nAnulowano operacje.");
                return;
            }
            DzialProgramowy.autorzy.Wypisz();
            Console.WriteLine("Podaj imie autora do usuniecia: ");
            imie = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko autora do usuniecia: ");
            nazwisko = Console.ReadLine();
            Console.Clear();
            autor = DzialProgramowy.autorzy.Znajdz(imie, nazwisko);
            if(autor == null)
            {
                Console.WriteLine("Takiego autora nie ma w bazie.\n");        //wyjatek - brak autora (albo w autorzy.Znajdz();
                return;
            }
            DzialProgramowy.autorzy.Usun(autor);
        }
        public static void usunAutora(Autor autor)
        {
            DzialProgramowy.autorzy.Usun(autor);
        }
        public static void usunUmowe()
        {
            Umowa umowa;
            string imie, nazwisko;
            Console.Clear();
            if (DzialProgramowy.umowy.Licz() == 0)
            {
                Console.WriteLine("Brak umow w bazie.\nAnulowano operacje.");
                return;
            }
            DzialProgramowy.umowy.Wypisz();
            Console.WriteLine("Podaj imie autora do usuniecia umowy: ");
            imie = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko autora do usuniecia umowy: ");
            nazwisko = Console.ReadLine();
            Console.Clear();
            umowa = DzialProgramowy.umowy.Znajdz(imie, nazwisko);
            if (umowa == null)
            {
                Console.WriteLine("Nie ma umowy z takim autorem.\n");        //wyjatek - brak umowy;
                return;
            }
            DzialProgramowy.umowy.Usun(umowa);
        }
        public static void usunUmowe(Umowa umowa)
        {
            DzialProgramowy.umowy.Usun(umowa);
        }
        public static void usunKsiazke()
        {
            string tyt;
            Console.Clear();
            if (DzialHandlowy.ksiazki.Licz() == 0)
            {
                Console.WriteLine("Brak ksiazek w bazie.\nAnulowano operacje.");
                return;
            }
            DzialHandlowy.ksiazki.Wypisz();
            Console.WriteLine("Podaj tytul ksiazki do usuniecia: ");
            tyt = Console.ReadLine();
            Console.Clear();
            Ksiazka ksiazka = DzialHandlowy.ksiazki.Znajdz(tyt);
            if (ksiazka == null)
            {
                Console.WriteLine("Takiej ksiazki nie ma w bazie.\n");
                return;
            }
            DzialHandlowy.ksiazki.Usun(ksiazka);
        }
        public static void usunKsiazke(Ksiazka ksiazka)
        {
            DzialHandlowy.ksiazki.Usun(ksiazka);
        }
        public static void usunCzasopismo()
        {
            string tyt;
            Console.Clear();
            if (DzialHandlowy.czasopisma.Licz() == 0)
            {
                Console.WriteLine("Brak czasopism w bazie.\nAnulowano operacje.");
                return;
            }
            DzialHandlowy.czasopisma.Wypisz();
            Console.WriteLine("Podaj tytul czasopisma do usuniecia: ");
            tyt = Console.ReadLine();
            Console.Clear();
            Czasopismo czasop = DzialHandlowy.czasopisma.Znajdz(tyt);
            if (czasop == null)
            {
                Console.WriteLine("Takiego czasopisma nie ma w bazie.\n");
                return;
            }
            DzialHandlowy.czasopisma.Usun(czasop);
        }
        public static void usunCzasopismo(Czasopismo czasop)
        {
            DzialHandlowy.czasopisma.Usun(czasop);
        }

    }
}
