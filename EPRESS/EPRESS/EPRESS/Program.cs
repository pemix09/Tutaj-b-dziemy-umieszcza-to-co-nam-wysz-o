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
            int m;
            Console.WriteLine("1. Dodaj element\n2. Usun element\n3. Wyswietl element\n4. Wczytaj baze z pliku\n5. Zapisz baze do pliku\n6. Drukuj ksiazki\n7. Drukuj czasopisma\n8. Wyjscie\nWybor: ");
            m = int.Parse(Console.ReadLine());
            switch (m)
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
                    DzialDruku.drukujKsiazki();
                    break;
                case 7:
                    DzialDruku.drukujCzasopisma();
                    break;
                case 8:
                    return 1;
                default:
                    Console.Clear();
                    Console.WriteLine("Podano nieprawidlowa wartosc.");
                    return 0;
            }
            Console.Clear();
            return 0;
        }
        private void dodawanie()  //Dodawanie Autora, publikacji, umowy itd. do naszej Bazy danych
        {                                   //różne konstruktory w zależności od typów parametrów?
            int m;
            Console.Clear();
            Console.WriteLine("Dodaj\n1. Autora\n2. Umowe\n3. Ksiazka\n4. Czasopismo\n");
            m = int.Parse(Console.ReadLine());
            switch (m)
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
                                
            int m;
            Console.Clear();
            Console.WriteLine("Usun\n1. Autora\n2. Umowe\n3. Ksiazka\n4. Czasopismo\n");
            m = int.Parse(Console.ReadLine());
            switch (m)
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
                    Console.WriteLine("Podano nieprawidlowa wartosc.");
                    break;
            }

        }
    
        private void wyswietlenie()
        {
            int m;
            Console.Clear();
            Console.WriteLine("Wyswietl\n1. Autorow\n2. Umowy\n3. Ksiazki\n4. Czasopisma\n");
            m = int.Parse(Console.ReadLine());
            switch (m)
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
            
        }
        private void wczytaj()
        {
            using (StreamReader file = new StreamReader("autorzy.txt"))
            {
                int iterator = 0;
                string imie = "";
                string nazwisko = "";

                string[] autorzy = file.ReadToEnd().Split(' ');
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
                        if(Start.autorzy.Znajdz(imie, nazwisko) == null)
                        {
                            autorN = new Autor(imie, nazwisko);
                        }
                        else
                        {
                            autorN = Start.autorzy.Znajdz(imie, nazwisko);
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
                string[] umowy = file.ReadToEnd().Split(' ');


                foreach (string umowa in umowy)
                {


                    if (iterator == 0)
                    { czastrwania = int.Parse(umowa); }
                    if (iterator == 1)
                    {
                        zarobki = float.Parse(umowa);
                    }
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
                        if (Start.autorzy.Znajdz(imieAutora, nazwiskoAutora) != null)
                        {
                           autorN = Start.autorzy.Znajdz(imieAutora, nazwiskoAutora);
                        }
                        else
                        {
                            autorN = new Autor(imieAutora, nazwiskoAutora);
                        }
                        if (Start.umowy.Znajdz(imieAutora, nazwiskoAutora)==null){
                            umowos = new Umowa(czastrwania, zarobki, autorN);
                        }
                        else
                        {
                            umowos = Start.umowy.Znajdz(imieAutora, nazwiskoAutora);
                        }
                        
                        Start.umowy.Dodaj(umowos);
                        iterator = 0;
                    }
                }
                file.Close();
            }
            using (StreamReader file= new StreamReader("czasopisma.txt"))
            {
                int iterator = 0;
                string tytul="";
                float cena=0;
                string typ="";
                string[] czasopisma = file.ReadToEnd().Split(' ');
                foreach(string czasopismo in czasopisma)
                {

                    if (iterator == 0)
                    { tytul = czasopismo;  }
                    if (iterator == 1)
                    { cena = float.Parse(czasopismo);  }
                    if(iterator==2)
                    { typ = czasopismo; }
                    iterator++;
                    if (iterator == 3)
                    {
                        if (typ == "czasopismo")
                        {
                            Czasopismo czasopism;
                            if (Start.czasopisma.Znajdz(tytul) == null)
                            {
                                czasopism = new Czasopismo(cena, tytul);
                            }
                            else
                            {
                                czasopism = Start.czasopisma.Znajdz(tytul);
                            }
                            Start.czasopisma.Dodaj(czasopism);
                        }
                        if (typ == "miesiecznik"){
                            Czasopismo czasopism;
                            if (Start.czasopisma.Znajdz(tytul) == null)
                            {
                                czasopism = new Miesiecznik(cena, tytul);
                            }
                            else
                            {
                                czasopism = Start.czasopisma.Znajdz(tytul);
                            }
                            Start.czasopisma.Dodaj(czasopism);
                        }
                        if (typ == "tygodnik")
                        {
                            Czasopismo czasopism;
                            if (Start.czasopisma.Znajdz(tytul) == null)
                            {
                                czasopism = new Tygodnik(cena, tytul);
                            }
                            else
                            {
                                czasopism =Start.czasopisma.Znajdz(tytul);
                            }
                            Start.czasopisma.Dodaj(czasopism);
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
                            if (Start.autorzy.Znajdz(imieAutora, nazwiskoAutora) == null)
                            {
                                autor = new Autor(imieAutora, nazwiskoAutora);
                            }
                            else
                            {
                                autor = Start.autorzy.Znajdz(imieAutora, nazwiskoAutora);
                               
                            }
                            if (Start.ksiazki.Znajdz(tytul) == null)
                            {
                                sensacyjna = new Sensacyjna(tytul, autor, rokwydania);
                            }
                            else
                            {
                                sensacyjna = Start.ksiazki.Znajdz(tytul);
                            }
                            Start.ksiazki.Dodaj(sensacyjna);
                        }
                        if (gatunek == "Romans")
                        {
                            Autor autor;
                            Ksiazka romans;
                            if (Start.autorzy.Znajdz(imieAutora, nazwiskoAutora) == null)
                            {
                                autor = new Autor(imieAutora, nazwiskoAutora);
                            }
                            else
                            {
                                autor = new Autor(imieAutora, nazwiskoAutora);
                                
                            }
                            if (Start.ksiazki.Znajdz(tytul) == null)
                            {
                                romans = new Romans(tytul, autor, rokwydania);
                            }
                            else
                            {
                                romans = Start.ksiazki.Znajdz(tytul);
                            }
                            Start.ksiazki.Dodaj(romans);
                        }
                        if (gatunek == "Album")
                        {
                            Autor autor;
                            Ksiazka album;
                            if (Start.autorzy.Znajdz(imieAutora, nazwiskoAutora) == null)
                            {
                                autor = new Autor(imieAutora, nazwiskoAutora);
                            }
                            else
                            {
                                autor = new Autor(imieAutora, nazwiskoAutora);
                             
                            }
                            if (Start.ksiazki.Znajdz(tytul) == null)
                            {
                                album = new Album(tytul, autor, rokwydania);
                            }
                            else
                            {
                                album = Start.ksiazki.Znajdz(tytul);
                            }
                            Start.ksiazki.Dodaj(album);
                        }
                        iterator = 0;
                    }

                }
                file.Close();
            }

          

        }
        private void zapisz()
        {

        }
    }
    class DzialDruku
    {
        private Drukarnie drukarnie;
        static public void drukujKsiazki()
        {
            string tytul;
            Ksiazka ksiazka;
            Console.Clear();
            WyswietlPoz.wysKsiazki();
            Console.WriteLine("Podaj tytul ksiazki: \n");
            tytul = Console.ReadLine();
            ksiazka = Start.ksiazki.Znajdz(tytul);
            if(ksiazka == null)
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
            czasopismo = Start.czasopisma.Znajdz(tytul);
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
        public List<Drukarnia> GetDrukarnie() { return drukarnie; }
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
        private Umowy umowy;
        private Autorzy autorzy;
        public Drukarnie druk = new Drukarnie();
        public Drukarnia WybierzDrukarnie(bool DrukujeAlbumy)
        {
           
               return druk.DajDrukarnie(DrukujeAlbumy);

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
            autorzy.Add(autor);
        }
        public List<Autor> GetAutorzy()
        {
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
            Console.WriteLine(imie + " " + nazwisko+"\n");
        }
    }
    class DzialHandlowy
    {
        private Czasopisma czasopisma;
        private Ksiazki ksiazki;
        public void zlecenie()
        {

        }
        public void oferta()
        {

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
    }
    class Tygodnik : Czasopismo 
    {
    public Tygodnik(float Cen, string tyt) : base(Cen, tyt) { }
    }
    class Miesiecznik : Czasopismo 
    {
        public Miesiecznik(float Cen, string tyt) : base(Cen, tyt) { }
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
        private string typ;

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
    }
    class Sensacyjna : Ksiazka 
    {
        public Sensacyjna(string tyt, Autor autor, int rokWyd) : base(tyt, autor, rokWyd){}
    }
    class Album : Ksiazka 
    {
        public Album(string tyt, Autor autor, int rokWyd) : base(tyt, autor, rokWyd) { }
    }
    class Romans : Ksiazka {
        public Romans(string tyt, Autor autor, int rokWyd) : base(tyt, autor, rokWyd) { }
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
