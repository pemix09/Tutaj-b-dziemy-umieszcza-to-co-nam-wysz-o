using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace EPRESS
{
    class DodajPoz
    {
        public static Autor dodajAutora()
        {
            string imie, nazwisko;
            Console.Clear();
            Console.WriteLine("Imie autora: ");
            imie = Console.ReadLine();
            Console.WriteLine("Nazwisko autora: ");
            nazwisko = Console.ReadLine();
            Console.Clear();
            Autor autor = new Autor(imie, nazwisko);
            DzialProgramowy.autorzy.Dodaj(autor);

            return autor;
        }
        public static void dodajAutora(Autor autor)
        {
            DzialProgramowy.autorzy.Dodaj(autor);
        }
        public static void dodajUmowe()
        {
            int czasTrwania, wybor, wybor2;
            float pensja;
            string imieTmp, nazwiskoTmp;
            Console.Clear();
            Autor autor = null;

            Console.Clear();
            Console.WriteLine("Podaj czas trwania umowy w miesiacach: ");
            czasTrwania = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj Pensje autora: ");
            pensja = float.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Podaj autora\n1. Nowy autor\n2. Istniejacy autor");
            wybor = int.Parse(Console.ReadLine());
            if (wybor == 1)
            {
                autor = dodajAutora();
            }
            else if (wybor == 2)
            {
                if (DzialProgramowy.autorzy.Licz() == 0)
                {
                    Console.WriteLine("Baza autorow jest pusta.\nAnulowano operacje.\n");
                    return;
                }
                Console.Clear();
                DzialProgramowy.autorzy.Wypisz();
                Console.WriteLine("Imie autora: ");
                imieTmp = Console.ReadLine();
                Console.WriteLine("Nazwisko autora: ");
                nazwiskoTmp = Console.ReadLine();
                Console.Clear();
                autor = DzialProgramowy.autorzy.Znajdz(imieTmp, nazwiskoTmp);
                if(autor == null)
                {
                    Console.WriteLine("Taki autor nie wystepuje w bazie.\nAnulowano operacje.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Nieodpowiedni wybor, nie udalo sie dodac autora!");         //+ wyjatki chyba trzeba dodac
                return;
            }
            Console.WriteLine("1. Umowa o prace.\n2. Umowa o dzielo\n");
            wybor2 = int.Parse(Console.ReadLine());
            Console.Clear();
            if (wybor2 == 1)
            {
                UmowaoPrace umowaoPrace = new UmowaoPrace(czasTrwania, pensja, autor);
                DzialProgramowy.umowy.Dodaj(umowaoPrace);
            }
            else if (wybor2 == 2)
            {
                UmowaoDzielo umowaoDzielo = new UmowaoDzielo(czasTrwania, pensja, autor);
                DzialProgramowy.umowy.Dodaj(umowaoDzielo);
            }
            else
            {
                Console.WriteLine("Nieodpowiedni wybor, nie udalo sie dodac autora!");         //+ wyrzucenie wyjatku
                return;
            }
            return;
        }
        public static void dodajUmowe(int czasTrw, float pensja, Autor autor)
        {
            Umowa umowa = new Umowa(czasTrw, pensja, autor);
            DzialProgramowy.umowy.Dodaj(umowa);
        }
        public static void dodajKsiazke()
        {
            Autor autor = null;
            string tytul, nazwiskoTmp, imieTmp;
            int rokWydania, wybor;
            Console.Clear();
            Console.WriteLine("Podaj tytul ksiazki: ");
            tytul = Console.ReadLine();
            Console.WriteLine("Podaj rok wydania: ");
            rokWydania = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Podaj autora\n1. Nowy autor\n2. Istniejacy autor");
            wybor = int.Parse(Console.ReadLine());
            Console.Clear();
            if (wybor < 1 || wybor > 2)
            {
                Console.WriteLine("Nieodpowiedni wybor, nie udalo sie dodac autora!");         //+ wyjatki chyba trzeba dodac
                return;
            }
            if (wybor == 1)
            {
                autor = dodajAutora();
            }
            else if (wybor == 2)
            {
                if (DzialProgramowy.autorzy.Licz() == 0)
                {
                    Console.WriteLine("Brak autorow w bazie.\nAnulowano operacje.\n");
                    return;
                }
                DzialProgramowy.autorzy.Wypisz();
                Console.WriteLine("Imie autora: ");
                imieTmp = Console.ReadLine();
                Console.WriteLine("Nazwisko autora: ");
                nazwiskoTmp = Console.ReadLine();
                Console.Clear();
                autor = DzialProgramowy.autorzy.Znajdz(imieTmp, nazwiskoTmp);
                if(autor == null)
                {
                    Console.WriteLine("Takiego autora nie ma w bazie.\nAnulowano operacje.\n");
                    return;
                }

            }
            Console.WriteLine("Typ ksiazki:\n1. Sensacyjna\n2. Romans\n3. Album");
            wybor = int.Parse(Console.ReadLine());
            Console.Clear();
            if (wybor == 1)
            {
                Sensacyjna ks = new Sensacyjna(tytul, autor, rokWydania);
                DzialHandlowy.ksiazki.Dodaj(ks);
            }
            else if(wybor == 2)
            {
                Romans ks = new Romans(tytul, autor, rokWydania);
                DzialHandlowy.ksiazki.Dodaj(ks);
            }
            else if(wybor == 3)
            {
                Album ks = new Album(tytul, autor, rokWydania);
                DzialHandlowy.ksiazki.Dodaj(ks);
            }
            else
            {
                Console.WriteLine("Nieodpowiedni wybor. Przypisano domyslny typ: ksiazka");
                Ksiazka ks = new Ksiazka(tytul, autor, rokWydania);
                DzialHandlowy.ksiazki.Dodaj(ks);
            }
            
        }
        public static void dodajCzasopismo()
        {
            float cena;
            string tytul;
            int wybor;
            
            Console.WriteLine("Podaj tytul czasopisma: ");
            tytul = Console.ReadLine();
            Console.WriteLine("Podaj cene czasopisma: ");
            cena = float.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Typ czasopisma:\n1. Tygodnik\n2. Miesiecznik");
            wybor = int.Parse(Console.ReadLine());
            if (wybor == 1)
            {
                Tygodnik czasop = new Tygodnik(cena, tytul);
                DzialHandlowy.czasopisma.Dodaj(czasop);
            }else if(wybor == 2)
            {
                Miesiecznik czasop = new Miesiecznik(cena, tytul);
                DzialHandlowy.czasopisma.Dodaj(czasop);
            }
            else
            {
                Console.WriteLine("Nieodpowiedni wybor. Przypisano domyslny typ: czasopismo");
                Czasopismo czasop = new Czasopismo(cena, tytul);
                DzialHandlowy.czasopisma.Dodaj(czasop);
            }
        }
    }
}
