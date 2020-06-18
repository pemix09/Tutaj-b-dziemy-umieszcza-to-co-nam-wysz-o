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
            if (Start.autorzy.Licz() == 0)
            {
                Console.WriteLine("Brak autorow w bazie.\nAnulowano operacje.");
                return;
            }
            Start.autorzy.Wypisz();
            Console.WriteLine("Podaj imie autora do usuniecia: ");
            imie = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko autora do usuniecia: ");
            nazwisko = Console.ReadLine();
            Console.Clear();
            autor = Start.autorzy.Znajdz(imie, nazwisko);
            if(autor == null)
            {
                Console.WriteLine("Takiego autora nie ma w bazie.\n");        //wyjatek - brak autora (albo w autorzy.Znajdz();
                return;
            }
            Start.autorzy.Usun(autor);
        }
        public static void usunAutora(Autor autor)
        {
            Start.autorzy.Usun(autor);
        }
        public static void usunUmowe()
        {
            Umowa umowa;
            string imie, nazwisko;
            Console.Clear();
            if (Start.umowy.Licz() == 0)
            {
                Console.WriteLine("Brak umow w bazie.\nAnulowano operacje.");
                return;
            }
            Start.umowy.Wypisz();
            Console.WriteLine("Podaj imie autora do usuniecia umowy: ");
            imie = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko autora do usuniecia umowy: ");
            nazwisko = Console.ReadLine();
            Console.Clear();
            umowa = Start.umowy.Znajdz(imie, nazwisko);
            if (umowa == null)
            {
                Console.WriteLine("Nie ma umowy z takim autorem.\n");        //wyjatek - brak umowy;
                return;
            }
            Start.umowy.Usun(umowa);
        }
        public static void usunUmowe(Umowa umowa)
        {
            Start.umowy.Usun(umowa);
        }
        public static void usunKsiazke()
        {
            string tyt;
            Console.Clear();
            if (Start.ksiazki.Licz() == 0)
            {
                Console.WriteLine("Brak ksiazek w bazie.\nAnulowano operacje.");
                return;
            }
            Start.ksiazki.Wypisz();
            Console.WriteLine("Podaj tytul ksiazki do usuniecia: ");
            tyt = Console.ReadLine();
            Console.Clear();
            Ksiazka ksiazka = Start.ksiazki.Znajdz(tyt);
            if (ksiazka == null)
            {
                Console.WriteLine("Takiej ksiazki nie ma w bazie.\n");
                return;
            }
            Start.ksiazki.Usun(ksiazka);
        }
        public static void usunKsiazke(Ksiazka ksiazka)
        {
            Start.ksiazki.Usun(ksiazka);
        }
        public static void usunCzasopismo()
        {
            string tyt;
            Console.Clear();
            if (Start.czasopisma.Licz() == 0)
            {
                Console.WriteLine("Brak czasopism w bazie.\nAnulowano operacje.");
                return;
            }
            Start.czasopisma.Wypisz();
            Console.WriteLine("Podaj tytul czasopisma do usuniecia: ");
            tyt = Console.ReadLine();
            Console.Clear();
            Czasopismo czasop = Start.czasopisma.Znajdz(tyt);
            if (czasop == null)
            {
                Console.WriteLine("Takiego czasopisma nie ma w bazie.\n");
                return;
            }
            Start.czasopisma.Usun(czasop);
        }
        public static void usunCzasopismo(Czasopismo czasop)
        {
            Start.czasopisma.Usun(czasop);
        }

    }
}
