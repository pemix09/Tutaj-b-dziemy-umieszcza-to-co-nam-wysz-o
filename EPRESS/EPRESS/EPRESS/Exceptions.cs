using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPRESS
{
    class Exception:System.Exception                                      //Nasza chierarchia wyjątków, clasa główna czyli Excepion dziedziczy z klasy systemowej 
    {                                                                     //o nazwie Exception
        public Exception(int number)
        {
            Console.WriteLine("Podano nie prawdiowa wartosc: " + number);
        }
        public Exception(string msg) : base(msg) { }
        public Exception(int number, string msg) : base(msg)
        {
            Console.WriteLine("Zly numer to: " + number);
        }
    }
    class EmptyFileException : Exception
    {
        public EmptyFileException(string msg) : base(msg) { }
    }
    class WrongSelectedNumber : Exception
    {
        public WrongSelectedNumber(int nr):base(nr) { }
        

        
    }
    class EmptyListException : Exception
    {
        public EmptyListException(string msg) : base(msg)
        {

        }
    }
    class WrongSubstractedNumber : Exception
    {
        public WrongSubstractedNumber(int nr, string msg):base(nr, msg) { }
    }

}
