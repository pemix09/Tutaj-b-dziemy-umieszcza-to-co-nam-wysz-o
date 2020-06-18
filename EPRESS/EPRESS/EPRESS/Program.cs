/*Wydawnictwo ePress wydaje pozycje: książki różnego rodzaju (sensacyjne, romanse, albumy, ...) oraz 2 rodzaje czasopism: tygodniki oraz miesięczniki. Współpracuje z autorami, których zatrudnia na umowę o pracę lub o dzieło (zajmuje się tym dział programowy wydawnictwa). Drukowaniem zarządza dział druku - odbywa się to w jednej z 3 własnych drukarni, z tym że tylko 1 z nich zapewnia wystarczającą jakość druku dla albumów.
Minimalny zakres funkcjonalności:

    -zarządzanie autorami (dodawanie, usuwanie, przegląd)

    -zarządzanie umowami i pozycjami (zawieranie umowy o pracę, zawieranie umowy o dzieło na konkretną pozycję, zlecanie w ramach umowy o pracę przygotowania konkretnej pozycji , rozwiązywanie, przegląd)

    -zarządzanie procesem drukowania: dział handlowy przygotowuje zlecenie druku i przesyła je do działu programowego, dział programowy wybiera pasującą drukarnię i przesyła jej zlecenie, drukarnia po wykonaniu druku powiadamia działy druku i handlowy, a ten ostatni wprowadza egzemplarze do swojej oferty

    -bardzo prosty sklep prowadzony przez dział handlowy (funkcjonalności: przyjmowanie zleceń zakupu pozycji zmniejszającej stan magazynowy i pokazywanie katalogu dostępnych pozycji)

    -zapis i odczyt stanu systemu na dysk*/
using System;
using System.Collections.Generic;
using System.Net;
using System.IO;

namespace EPRESS
{  
    class ePress
    {

        public int init()
        {
            int wybor;
            Console.WriteLine("1. Dodaj element\n2. Usun element\n3. Wyswietl element\n4. Wczytaj baze z pliku\n5. Zapisz baze do pliku\n6. Drukowanie\n7. Sklep\n8. Wyjscie\nWybor: ");
            wybor = int.Parse(Console.ReadLine());
            switch (wybor)
            {
                case 1:
                    dodawanie();
                    break;
                case 2:
                    usuwanie();
                    break;
                case 3:
                    wyswietlenie();
                    break;
                case 4:
                    wczytaj();
                    break;
                case 5:
                    zapisz();
                    break;
                case 6:
                    drukowanie();
                    break;
                case 7:
                    DzialHandlowy.sklep();
                    break;
                case 8:
                    return 1;
                default:
                    Console.Clear();
                    Console.WriteLine("Podano nieprawidlowa wartosc.");
                    return 0;
            }
           
            return 0;
        }
        private void dodawanie()                                                        //metoda dodawanie, która za pomocą menu tekstowego umozliwia dodanie odpowiedniego obiektu
        {                                 
            int wybor;
            Console.Clear();
            Console.WriteLine("Dodaj\n1. Autora\n2. Umowe\n3. Ksiazka\n4. Czasopismo\n");
            wybor = int.Parse(Console.ReadLine());
            switch (wybor)
            {
                case 1:
                    DodajPoz.dodajAutora();
                    break;
                case 2:
                    DodajPoz.dodajUmowe();
                    break;
                case 3:
                    DodajPoz.dodajKsiazke();
                    break;
                case 4:
                    DodajPoz.dodajCzasopismo();
                    break;
                default:
                    Console.WriteLine("Podano nieprawidlowa wartosc.");
                    break;
            }

        }
        private void usuwanie()
        {                       
                                
            int wybor;
            Console.Clear();
            Console.WriteLine("Usun\n1. Autora\n2. Umowe\n3. Ksiazka\n4. Czasopismo\n");
            wybor = int.Parse(Console.ReadLine());
            switch (wybor)                                                  //konstrukcja switch()case, pozwala nam na wybranie, co się stanie po wpisaniu
                                                                            //opowiedniej wartosci do zmiennej wybor
            {
                case 1:
                    UsunPoz.usunAutora();
                    break;
                case 2:
                    UsunPoz.usunUmowe();
                    break;
                case 3:
                    UsunPoz.usunKsiazke();
                    break;
                case 4:
                    UsunPoz.usunCzasopismo();
                    break;
                default:
                    Console.WriteLine("Podano nieprawidlowa wartosc.");     //Informujemy uzytkownika ze wpisał nieprawidłową wartosc              
                    break;
            }

        }
    
        private void wyswietlenie()
        {
            int wybor;
            Console.Clear();                                                                       //Console.clear() Pozwala na czyszczenie tego, co mamy na ekranie, przez co
            Console.WriteLine("Wyswietl\n1. Autorow\n2. Umowy\n3. Ksiazki\n4. Czasopisma\n");       //program wygląda ładnie, nawet jesli nie jest tekstowy
            wybor = int.Parse(Console.ReadLine());
            switch (wybor)
            {
                case 1:
                    WyswietlPoz.wysAutorow();
                    break;
                case 2:
                    WyswietlPoz.wysUmowy();
                    break;
                case 3:
                    WyswietlPoz.wysKsiazki();
                    break;
                case 4:
                    WyswietlPoz.wysCzasopisma();
                    break;
                default:
                    Console.WriteLine("Podano nieprawidlowa wartosc.");
                    break;
            }
        }
        private void drukowanie()
        {
            int wybor;
            Console.Clear();
            Console.WriteLine("1. Drukuj ksiazki.\n2. Drukuj czasopisma.");
            wybor = int.Parse(Console.ReadLine());
            if (wybor == 1)
            {
                DzialDruku.drukujKsiazki();
            }else if (wybor == 2)
            {
                DzialDruku.drukujCzasopisma();
            }
            else
            {
                Console.WriteLine("Nieodpowiednia wartosc.\nAnulowano operacje.\n");
                return;
            }
        }
        private void wczytaj()
        {
            Console.Clear();
            using (StreamReader file = new StreamReader("autorzy.txt"))
            {
                int iterator = 0;
                string imie = "";
                string nazwisko = "";
                string[] autorzy = file.ReadToEnd().Split(' ');
                if (autorzy == null)
                {
                    throw new EmptyFileException("Plik autorzy.txt, z ktorego chcesz wczytac jest pusty lub nie mozliwy do oczytania!");
                }
                foreach (string autor in autorzy)
                {

                    if (iterator == 0)
                    { imie = autor; }
                    if (iterator == 1)
                    { nazwisko = autor;  }

                    iterator++;
                    if (iterator == 2)
                    {

                        Autor autorN;
                        if(DzialProgramowy.autorzy.Znajdz(imie, nazwisko) == null)
                        {
                            autorN = new Autor(imie, nazwisko);
                        }
                        else
                        {
                            autorN = DzialProgramowy.autorzy.Znajdz(imie, nazwisko);
                        }
                        DodajPoz.dodajAutora(autorN);
                        iterator = 0;
                    }
                }
                file.Close();
            }
            using (StreamReader file = new StreamReader("umowy.txt"))
            {
                int iterator = 0;
                int czastrwania = 0;
                float zarobki = 0;
                string imieAutora = "";
                string nazwiskoAutora = "";
                string[] umowy = file.ReadToEnd().Split(' ');//Metoda ta powoduje, ze wszystko co jest w zmiennej StreamReader o nazwie file jest dodawanie do tablicy
                                                                //znakiem oddzielenia jest spacja, co jest oznaczone jako ' '
                if (umowy == null)
                {
                    throw new EmptyFileException("Plik umowy.txt, z ktorego chcesz wczytac jest pusty lub jest nie mozliwy do oczytania!");
                }


                foreach (string umowa in umowy)
                {


                    if (iterator == 0)
                    { czastrwania = int.Parse(umowa); }                 //konwertujemy do typu int, poniwaz wejscie jest w typie string 
                    if (iterator == 1)
                    {
                        zarobki = float.Parse(umowa);                   //musimy skonwertować naszą wartości wczytaną z pliku do typu float, poniewaz streamreader czyta stringi
                    }                                                   //jako wejscie, których nie mozna traktowac jak liczby
                    if (iterator == 2)
                    {
                        imieAutora = umowa; 
                    }
                    if (iterator == 3)
                    {
                        nazwiskoAutora = umowa;
                    }
                    iterator++;                                          
                    if (iterator == 4)
                    {
                        Autor autorN;
                        Umowa umowos;
                        if (DzialProgramowy.autorzy.Znajdz(imieAutora, nazwiskoAutora) != null)           //metoda DzialProgramowy.autorzy.znajdz(obiekt) mówi nam czy taki obiekt jest w naszej bazie 
                        {                                                                       //i jesli jest to zwraca nam referencje do tego obiektu, jesli nie ma to zwraca wartosc
                           autorN = DzialProgramowy.autorzy.Znajdz(imieAutora, nazwiskoAutora);           //null, która mówi nam ze trzeba stworzyc nowy obiekt
                        }
                        else
                        {
                            autorN = new Autor(imieAutora, nazwiskoAutora);
                            DzialProgramowy.autorzy.Dodaj(autorN);
                        }
                        if (DzialProgramowy.umowy.Znajdz(imieAutora, nazwiskoAutora)==null){
                            umowos = new Umowa(czastrwania, zarobki, autorN);
                            DzialProgramowy.umowy.Dodaj(umowos);
                        }
                        else
                        {
                            umowos = DzialProgramowy.umowy.Znajdz(imieAutora, nazwiskoAutora);
                            DzialProgramowy.umowy.Dodaj(umowos);
                        }
                        
                        
                        iterator = 0;
                    }
                }
                file.Close();
            }
            using (StreamReader file= new StreamReader("czasopisma.txt"))
            {
                int iterator = 0;                           //ustawiamy wartosci poczatkowe zmiennych na "domyślne " wartości zeby kompilator nie krzyczal o nie zadeklarowanej
                string tytul="";                            //zmiennej
                float cena=0;
                string typ="";
                string[] czasopisma = file.ReadToEnd().Split(' '); //Metoda ta powoduje, ze wszystko co jest w zmiennej StreamReader o nazwie file jest dodawanie do tablicy
                if (czasopisma == null)                            //stringów, a znakiem odzielenia jest spacja co jest oznaczone jako ' '
                {                                                   //wyrzucamy wyjątek jeśli nasza tablica stringów jest pusta, to znak ze plik jest pusty!
                    throw new EmptyFileException("Plik czasopisma.txt, z ktorego chcesz wczytac jest pusty, lub nie mozliwy do oczytania!");
                }
                foreach (string czasopismo in czasopisma)
                {

                    if (iterator == 0)                                          //Mamy tutaj iterator, ktory moze przybrac wartosc maksymalnie 3, pomaga nam on zeby z tablicy
                    { tytul = czasopismo;  }                                    //stringów wybrać pojedyńcze elementy, takie jak tytuł, typ, cena, po osiagnieciu wartosci 3, po
                    if (iterator == 1)                                          //wykonaniu instrukcji dodania odpowiedniego czasopisma do zbioru czasopism, zerujemy go by mogl 
                    { cena = float.Parse(czasopismo);  }                        //dodać kolejne czasopisma
                    if(iterator==2)
                    { typ = czasopismo; }
                    iterator++;
                    if (iterator == 3)
                    {
                        if (typ == "czasopismo")
                        {
                            Czasopismo czasopism;
                            if (DzialHandlowy.czasopisma.Znajdz(tytul) == null)             //metoda Start.czasopsima.Znajdz(obiekt) zwraca nam referencję do obiektu, jeśli taki
                            {                                                       //obiekt istnieje w naszej bazie, a jesli nie ma takiego to zwraca nam wartosc null, ktora
                                czasopism = new Czasopismo(cena, tytul);            //mówi, ze mozemy stworzyc nowy obiekt
                            }
                            else
                            {
                                czasopism = DzialHandlowy.czasopisma.Znajdz(tytul);
                            }
                            DzialHandlowy.czasopisma.Dodaj(czasopism);
                        }
                        if (typ == "miesiecznik"){
                            Czasopismo czasopism;
                            if (DzialHandlowy.czasopisma.Znajdz(tytul) == null)
                            {
                                czasopism = new Miesiecznik(cena, tytul);
                            }                                                         //w zaleznosci z jakim typem czasopisma mamy do czynienia, korzystamy z odpowiednich
                            else                                                      //metod dodania czasopisma
                            {
                                czasopism = DzialHandlowy.czasopisma.Znajdz(tytul);
                            }
                            DzialHandlowy.czasopisma.Dodaj(czasopism);
                        }
                        if (typ == "tygodnik")
                        {
                            Czasopismo czasopism;
                            if (DzialHandlowy.czasopisma.Znajdz(tytul) == null)
                            {
                                czasopism = new Tygodnik(cena, tytul);
                            }
                            else
                            {
                                czasopism =DzialHandlowy.czasopisma.Znajdz(tytul);
                            }
                            DzialHandlowy.czasopisma.Dodaj(czasopism);
                        }
                        
                        iterator = 0;
                    }
                }
                file.Close();
            }
            using(StreamReader file=new StreamReader("ksiazki.txt"))
            {
                int iterator = 0;
                string tytul="";
                int rokwydania=0;
                string imieAutora="";
                string nazwiskoAutora="";
                string gatunek="";
                string[] ksiazki = file.ReadToEnd().Split(' ');
                if (ksiazki == null)
                {
                    throw new EmptyFileException("Plik ksiazki.txt, z ktorego chcesz wczytac jest pusty!");
                }
                foreach (string ksiazka in ksiazki)
                {
                    if (iterator == 0) { tytul= ksiazka; }
                    if (iterator == 1) { rokwydania = int.Parse(ksiazka); }
                    if(iterator == 2) { imieAutora = ksiazka; }
                    if (iterator == 3) { nazwiskoAutora = ksiazka; }
                    if (iterator == 4) { gatunek = ksiazka; }
                    iterator++;
                    if (iterator == 5)
                    {
                        if (gatunek == "Sensacyjna")
                        {
                            Autor autor;
                            Ksiazka sensacyjna;
                            if (DzialProgramowy.autorzy.Znajdz(imieAutora, nazwiskoAutora) == null)
                            {
                                autor = new Autor(imieAutora, nazwiskoAutora);
                            }
                            else
                            {
                                autor = DzialProgramowy.autorzy.Znajdz(imieAutora, nazwiskoAutora);
                               
                            }
                            if (DzialHandlowy.ksiazki.Znajdz(tytul) == null)
                            {
                                sensacyjna = new Sensacyjna(tytul, autor, rokwydania);
                            }
                            else
                            {
                                sensacyjna = DzialHandlowy.ksiazki.Znajdz(tytul);
                            }
                            DzialHandlowy.ksiazki.Dodaj(sensacyjna);
                        }
                        if (gatunek == "Romans")
                        {
                            Autor autor;
                            Ksiazka romans;
                            if (DzialProgramowy.autorzy.Znajdz(imieAutora, nazwiskoAutora) == null)
                            {
                                autor = new Autor(imieAutora, nazwiskoAutora);
                            }
                            else
                            {
                                autor = new Autor(imieAutora, nazwiskoAutora);
                                
                            }
                            if (DzialHandlowy.ksiazki.Znajdz(tytul) == null)
                            {
                                romans = new Romans(tytul, autor, rokwydania);
                            }
                            else
                            {
                                romans = DzialHandlowy.ksiazki.Znajdz(tytul);
                            }
                            DzialHandlowy.ksiazki.Dodaj(romans);
                        }
                        if (gatunek == "Album")
                        {
                            Autor autor;
                            Ksiazka album;
                            if (DzialProgramowy.autorzy.Znajdz(imieAutora, nazwiskoAutora) == null)
                            {
                                autor = new Autor(imieAutora, nazwiskoAutora);
                            }
                            else
                            {
                                autor = new Autor(imieAutora, nazwiskoAutora);
                             
                            }
                            if (DzialHandlowy.ksiazki.Znajdz(tytul) == null)
                            {
                                album = new Album(tytul, autor, rokwydania);
                            }
                            else
                            {
                                album = DzialHandlowy.ksiazki.Znajdz(tytul);
                            }
                            DzialHandlowy.ksiazki.Dodaj(album);
                        }
                        if (gatunek == "Ksiazka")
                        {
                            Autor autor;
                            Ksiazka ksiazkaa;
                            if (DzialProgramowy.autorzy.Znajdz(imieAutora, nazwiskoAutora) == null)
                            {
                                autor = new Autor(imieAutora, nazwiskoAutora);
                            }
                            else
                            {
                                autor = new Autor(imieAutora, nazwiskoAutora);

                            }
                            if (DzialHandlowy.ksiazki.Znajdz(tytul) == null)
                            {
                                ksiazkaa = new Album(tytul, autor, rokwydania);
                            }
                            else
                            {
                                ksiazkaa = DzialHandlowy.ksiazki.Znajdz(tytul);
                            }
                            DzialHandlowy.ksiazki.Dodaj(ksiazkaa);

                        }
                        iterator = 0;
                    }

                }
                file.Close();
            }
            Console.WriteLine("Wczytano.\n");
          

        }
        private void zapisz()
        {
            using (StreamWriter file = new StreamWriter("autorzy.txt"))
            {
                foreach (Autor autor in DzialProgramowy.autorzy.GetAutorzy())
                {
                    file.Write(autor.GetImie() + " " + autor.GetNazwisko() + " ");
                }
                file.Close();
            }
            using(StreamWriter file=new StreamWriter("umowy.txt"))
            {
                foreach(Umowa umowa in DzialProgramowy.umowy.GetUmowy())
                {

                    file.Write(umowa.GetCzasTrwania() + " " + umowa.GetWynagrodzenie() + " " + umowa.GetAutor().GetImie() + " " + umowa.GetAutor().GetNazwisko() + " ");
                }
                file.Close();
            }
            using(StreamWriter file = new StreamWriter("czasopisma.txt"))
            {
                foreach(Czasopismo czasopismo in DzialHandlowy.czasopisma.GetPisma())
                {
                    file.Write(czasopismo.GetTytyul() + " " + czasopismo.GetCena() + " " + czasopismo.GetTyp() + " ");
                }
                file.Close();
            }
            using(StreamWriter file = new StreamWriter("ksiazki.txt"))
            {
                foreach(Ksiazka ksiazka in DzialHandlowy.ksiazki.GetKsiazki())
                {
                    file.Write(ksiazka.GetTytul() + " " + ksiazka.GetRokWydania() + " " + ksiazka.GetAutor().GetImie() + " " + ksiazka.GetAutor().GetNazwisko() + " "+ksiazka.GetTyp()+" ");
                }
                file.Close();
            }
            Console.WriteLine("Zapisano");
        }
    }
    class DzialDruku
    {
        public static Drukarnie drukarnie = new Drukarnie();
        static public void drukujKsiazki()
        {
            string tytul;
            Ksiazka ksiazka;
            Console.Clear();
            WyswietlPoz.wysKsiazki();
            Console.WriteLine("Podaj tytul ksiazki: \n");
            tytul = Console.ReadLine();
            ksiazka = DzialHandlowy.ksiazki.Znajdz(tytul);                      //Metoda DzialHandlowy.ksiazki.znajdz(obiekt) mówi nam czy dany obiekt znajduje się w naszej bazie, jesli tak
            if(ksiazka == null)                                         //zwraca referencje do obiektu, jesli nie to zwraca wartosc null, oznaczającą, ze obiektu nie ma
            {
                Console.WriteLine("Nie ma ksiazki w bazie.\nDodaj ksiazke.");
                DodajPoz.dodajKsiazke();
            }
            Console.WriteLine("Podaj ilosc ksiazek do wydrukowania: ");
            ksiazka.DodajIlosc(Convert.ToInt32(Console.ReadLine()));
            Console.Clear();
        }
        static public void drukujCzasopisma()
        {
            string tytul;
            Czasopismo czasopismo;
            Console.Clear();
            WyswietlPoz.wysCzasopisma();
            Console.WriteLine("Podaj tytul czasopisma: \n");
            tytul = Console.ReadLine();
            czasopismo = DzialHandlowy.czasopisma.Znajdz(tytul);
            if (czasopismo == null)
            {
                Console.WriteLine("Nie ma czasopisma w bazie.\nDodaj czasopismo.");
                DodajPoz.dodajCzasopismo();
            }
            Console.WriteLine("Podaj ilosc czasopism do wydrukowania: ");
            czasopismo.DodajIlosc(Convert.ToInt32(Console.ReadLine()));
            Console.Clear();
        }
        public void wydrukowano()
        {

        }
    }
    class Drukarnie 
    {
        private List<Drukarnia> drukarnie;
        public Drukarnie()
        {
            drukarnie = new List<Drukarnia>();
        }
        public List<Drukarnia> GetDrukarnie() 
        {
            if (drukarnie == null) { throw new EmptyListException("Lista drukarni jest pusta!"); }
            
            return drukarnie; }
        public Drukarnia DajDrukarnie(bool CzyAlbum)
        {
            foreach(Drukarnia druk in drukarnie)
            {
                if (druk.GetMozeAlbumy() == CzyAlbum) { return druk; }
                
            }
            return null;
        }
    }
    class Drukarnia
    {
        private string nazwa;
        private bool czyMozeAlbumy;
        public Drukarnia(string nazwaa, bool czymoze)
        {
            nazwa = nazwaa;
            czyMozeAlbumy = czymoze;
        }
        public string GetNazwa() { return nazwa; }
        public bool GetMozeAlbumy() { return czyMozeAlbumy; }
    }
    class DzialProgramowy
    {
        public static Autorzy autorzy = new Autorzy();
        public static Umowy umowy = new Umowy();

        public Drukarnia WybierzDrukarnie(bool DrukujeAlbumy)
        {
           
               return DzialDruku.drukarnie.DajDrukarnie(DrukujeAlbumy);

        }
        public void Zatrudnij()
        {

        }
        public void Przeslij()
        {

        }
    }
    public class Umowy
    {
        private List<Umowa> umowy;
        public Umowy()
        {
            umowy = new List<Umowa>();
        }
        public void Dodaj(Umowa umowa)
        {
            umowy.Add(umowa);
        }
        public void Usun(Umowa umowa)
        {
            umowy.Remove(umowa);
        }
        public List<Umowa> GetUmowy()
        {
            if (umowy == null) { throw new EmptyListException("lista Umow jest pusta!"); }
            return umowy;
        }
        public int Licz()
        {
            return umowy.Count;
        }
        public void Wypisz()
        {
            if (umowy.Count == 0)
                Console.WriteLine("Brak umow w bazie.");
            else
                foreach (Umowa umowa in umowy)
            {
                umowa.Wypisz();
            }
        }
        public Umowa Znajdz(string imie, string nazwisko)
        {
            foreach (Umowa umowa in umowy)
            {
                if ( (String.Compare(umowa.GetAutor().GetNazwisko(), nazwisko) == 0) && (String.Compare(umowa.GetAutor().GetImie(), imie) == 0) )
                    return umowa;
            }
            return null;
        }
    }
    public class Umowa
    {
        public int CzastrwaniaUmowy { private get; set; }
        public float wynagrodzenie { private get; set; }
        public Autor autor { private get; set; }
        public Umowa(int CzasTrwania,float wynag, Autor Autor)
        {
            CzastrwaniaUmowy = CzasTrwania;
            wynagrodzenie = wynag;
            autor = Autor;
        }

        public int GetCzasTrwania() { return CzastrwaniaUmowy; }
        public float GetWynagrodzenie() { return wynagrodzenie; }
        public Autor GetAutor() { return autor; }
        public void Wypisz()
        {
            Console.WriteLine("Autor: " + autor.GetImie()+" "+autor.GetNazwisko() +" | Czas trwania: "+CzastrwaniaUmowy+" | Wynagrodzenie: "+wynagrodzenie+" | "+GetType().ToString().Substring(7)+"\n");
        }

    }
    class UmowaoPrace : Umowa 
    {
        public UmowaoPrace(int czasTrwania, float wynag, Autor autor):base(czasTrwania,wynag,autor)
                                                                  
        {
            this.CzastrwaniaUmowy = czasTrwania;
            this.wynagrodzenie = wynag;
            this.autor = autor;
        }
    }
    class UmowaoDzielo : Umowa 
    {
        public UmowaoDzielo(int czasTrwania, float wynag, Autor autor) : base(czasTrwania,wynag,autor)
        { 
            this.CzastrwaniaUmowy = czasTrwania;
            this.wynagrodzenie = wynag;
            this.autor = autor;
        }
    }
    public class Autorzy
    {
        private List<Autor> autorzy;

        public Autorzy()
        {
            autorzy = new List<Autor>();
        }
        public void Dodaj(Autor autor)
        {
            autorzy.Add(autor);
        }
        public void Usun(Autor autor)
        {
            autorzy.Remove(autor);
        }
        public List<Autor> GetAutorzy()
        {
            if (autorzy == null) { throw new EmptyListException("Lista Autorow jest pusta! "); }
            return autorzy;
        }
        public int Licz()
        {
            return autorzy.Count;
        }
        public void Wypisz ()
        {
            if (autorzy.Count == 0)
                Console.WriteLine("Brak autorow w bazie.");
            else
            foreach(Autor autor in autorzy)
            {
                autor.Wypisz();
            }
        }
        public Autor Znajdz(string imie, string nazwisko)
        {
            foreach(Autor autor in autorzy)
            {
                if ((String.Compare(autor.GetNazwisko(), nazwisko)==0)&&(String.Compare(autor.GetImie(), imie) == 0))
                    return autor;

            }
            return null;
        }
    }
    public class Autor
    {
        private string imie;
        private string nazwisko;
        Autor() { }
        public Autor(string im, string naz)
        {
            imie = im;
            nazwisko = naz;
        }
        public string GetImie() { return imie; }
        public string GetNazwisko() { return nazwisko; }
        public void Wypisz()
        {
            Console.WriteLine(imie + " " + nazwisko);
        }
    }
    class DzialHandlowy
    {
        public static Ksiazki ksiazki = new Ksiazki();
        public static Czasopisma czasopisma = new Czasopisma();


        public static void sklep()
        {
            int wybor;
            Console.Clear();
            Console.WriteLine("1. Wyswietl oferte.\n2. Sprzedaz.\n");
            wybor = int.Parse(Console.ReadLine());              //input konwertujemy na int. ponieważ input jest typu string
            if (wybor == 1)
            {
                oferta();
            }else if (wybor == 2)
            {
                zlecenie();
            }
            else
            {
                Console.WriteLine("Nieodpowiednia wartosc.\nAnulowano operacje.\n");
       

                return;
            }
        }
        public static void zlecenie()
        {
            int wybor=0;
            int ilosc=0;
            string tytul="";
            Console.Clear();
            Console.WriteLine("Sprzedano:\n1. Ksiazki.\n2. Czasopisma.\n");
            wybor = int.Parse(Console.ReadLine());
            Console.Clear();
            if(wybor<1 || wybor > 2)
            {
                Console.WriteLine("Nieodpowiednia wartosc.\n Anulowano operacje.\n");
                
                return;
            }
            Console.WriteLine("Ilosc sprzedanych egemplarzy: ");
            ilosc = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj tytul sprzedanej pozycji: ");
            tytul = Console.ReadLine();
            Console.Clear();
            if (wybor == 1)
            {
                if (DzialHandlowy.ksiazki.Znajdz(tytul) == null)
                {
                    Console.WriteLine("Brak takiej ksiazki w bazie.");
                    return;
                }
                DzialHandlowy.ksiazki.Znajdz(tytul).ZmniejszIlosc(ilosc);
            }else if(wybor == 2)
            {
                if (DzialHandlowy.czasopisma.Znajdz(tytul) == null)
                {
                    Console.WriteLine("Brak takiego czasopisma w bazie.\n");
                    return;
                }
                DzialHandlowy.czasopisma.Znajdz(tytul).ZmniejszIlosc(ilosc);
            }
        }
        public static void oferta()
        {
            Console.Clear();
            Console.WriteLine("---OFERTA---\n**KSIAZKI**\n");
            DzialHandlowy.ksiazki.Wypisz();
            Console.WriteLine("\n**CZASOPISMA**\n");
            DzialHandlowy.czasopisma.Wypisz();
        }
        public void przeslij()
        {

        }
    }
    public class Czasopismo
    {
        private int ilosc=0;
        private float cena;
        private string tytul;
        
        
        public Czasopismo(float Cen,string tyt)
        {
            cena = Cen;
            tytul = tyt;
        }
        public string GetTytyul()
        {
            return tytul;
        }
        public float GetCena()
        {
            return cena;
        }
        public int GetIlosc()
        {
            return this.ilosc;
        }
        public void DodajIlosc(int ilosc)
        {
            this.ilosc += ilosc;
        }
        public void ZmniejszIlosc(int ilosc)
        {
            if (this.ilosc < ilosc) { throw new WrongSubstractedNumber(ilosc, "Odjeto wiecej ksiazke niz jest w bazie!"); }

            this.ilosc -= ilosc;
        }
        public virtual string GetTyp()              //korzystamy tutaj z klasy wirtualnej, żeby metoda GetTyp() zwracała dobrą wartość, zależną od swojej klasy
        {
            
            return "Czasopismo";
        }
    }
    class Tygodnik : Czasopismo 
    {
    public Tygodnik(float Cen, string tyt) : base(Cen, tyt) { }
        public override string GetTyp() { return "Tygodnik"; }
    }
    class Miesiecznik : Czasopismo 
    {
        public Miesiecznik(float Cen, string tyt) : base(Cen, tyt) { }
        public override string GetTyp() { return "Miesiecznik"; }
    }
    public class Czasopisma
    {
        private List<Czasopismo> czasopisma;
        public Czasopisma()
        {
            czasopisma = new List<Czasopismo>();
        }
        public void Dodaj(Czasopismo czasopismo)
        {
            czasopisma.Add(czasopismo);
        }
        public void Usun(Czasopismo czasopismo)
        {
            czasopisma.Remove(czasopismo);
        }
        public List<Czasopismo> GetPisma()
        {
            if (czasopisma == null) { throw new EmptyListException("Lista czasopism jest pusta!"); }
            return czasopisma;
        }
        public int Licz()
        {
            return czasopisma.Count;
        }
        public Czasopismo Znajdz(string tyt)
        {
            foreach (Czasopismo czasop in czasopisma)
            {
                if ((String.Compare(czasop.GetTytyul(),tyt) == 0))
                    return czasop;

            }
            return null;
        }
        public void Wypisz()
        {
            if (czasopisma.Count == 0)
                Console.WriteLine("Brak czasopism w bazie.");
            else
                foreach (Czasopismo gazeta in czasopisma)
            {
                Console.WriteLine(gazeta.GetTytyul()+" | Cena: "+gazeta.GetCena()+" | "+gazeta.GetType().ToString().Substring(7)+" | Ilosc czasopism na magazynie: "+gazeta.GetIlosc()+"\n");
            }
        }
    }
    public class Ksiazki
    {
        private List<Ksiazka> ksiazki;
        public Ksiazki()
        {
             
            ksiazki = new List<Ksiazka>();
        }
        public void Dodaj(Ksiazka ksiazka)
        {
            ksiazki.Add(ksiazka);
        }
        public void Usun(Ksiazka ksiazka)
        {
            ksiazki.Remove(ksiazka);
        }
        public List<Ksiazka> GetKsiazki()
        {
            if (ksiazki == null)
            {
                throw new EmptyListException("Lista ksiazek jest pusta!");
            }
                return ksiazki;
        }
        public int Licz()
        {
            return ksiazki.Count;
        }
        public Ksiazka Znajdz(string tytul)
        {
            foreach (Ksiazka ksiazka in ksiazki)
            {
                if ((String.Compare(ksiazka.GetTytul(),tytul) == 0))
                    return ksiazka;

            }
            return null;
        }
        public void Wypisz()
        {
            if (ksiazki.Count == 0)
                Console.WriteLine("Brak ksiazek w bazie.");
            else
                foreach (Ksiazka ksiazka in ksiazki)
            {
                Console.WriteLine(ksiazka.GetTytul() + " Autor: " + ksiazka.GetAutor().GetImie()+" "+ksiazka.GetAutor().GetNazwisko() + " | Rok wydania: " + ksiazka.GetRokWydania()+" | "+ksiazka.GetType().ToString().Substring(7)+ " | Ilosc ksiazek na magazynie: "+ksiazka.GetIlosc()+"\n");
            }
        }
    }
    public class Ksiazka
    {
        private int ilosc = 0;
        private string tytul;
        private Autor Autor;
        private int RokWydania;

        public Ksiazka(string tyt,Autor autor, int rokWyd)
        {
            tytul = tyt;
            Autor = autor;
            RokWydania = rokWyd;
        }
        public string GetTytul()
        {
            return tytul;
        }
        public int GetIlosc()
        {
            return ilosc;
        }
        public int GetRokWydania()
        {
            return RokWydania;
        }
        public Autor GetAutor()
        {
            return Autor;
        }
        public void DodajIlosc(int ilosc)
        {
            this.ilosc += ilosc;
        }
        public void ZmniejszIlosc(int ilosc)
        {
            if (ilosc > this.ilosc) { throw new WrongSubstractedNumber(ilosc, "W bazie jest mniej ksiazek niz probujesz odjac!"); }
            this.ilosc -= ilosc;
        }
        public virtual string GetTyp() { return "Ksiazka"; }
    }
    class Sensacyjna : Ksiazka 
    {
        public Sensacyjna(string tyt, Autor autor, int rokWyd) : base(tyt, autor, rokWyd){}
        public override string GetTyp() { return "Sensacyjna"; }
    }
    class Album : Ksiazka 
    {
        public Album(string tyt, Autor autor, int rokWyd) : base(tyt, autor, rokWyd) { }
        public override string GetTyp() { return "Album"; }
    }
    class Romans : Ksiazka {
        public Romans(string tyt, Autor autor, int rokWyd) : base(tyt, autor, rokWyd) { }
        public override string GetTyp() { return "Romans"; }
    }
    class MainClass
    {
        public static void Main()
        {
            int m;
            
            ePress wydawnictowo = new ePress();
            do
            {
                m = wydawnictowo.init();
                
            } while (m == 0);
            
        }
    }
}
