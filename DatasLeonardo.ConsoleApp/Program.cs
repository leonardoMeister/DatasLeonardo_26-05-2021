using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatasLeonardo.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {



            
            PeriodoPassado aux = new PeriodoPassado(new DateTime(2021, 05, 26, 20, 59, 48));
            Console.WriteLine(aux.StringDataExtenso + "\n");

            /*

            aux = new PeriodoPassado(new DateTime(2021, 05, 27));
            Console.WriteLine(aux.StringDataExtenso + "\n");



            aux = new PeriodoPassado(new DateTime(2021, 04, 18));
            Console.WriteLine(aux.StringDataExtenso + "\n");

            aux = new PeriodoPassado(new DateTime(2001, 08, 17));
            Console.WriteLine(aux.StringDataExtenso + "\n");

            aux = new PeriodoPassado(new DateTime(2001, 07, 20));
            Console.WriteLine(aux.StringDataExtenso + "\n");

            aux = new PeriodoPassado(new DateTime(2001, 07, 21));
            Console.WriteLine(aux.StringDataExtenso + "\n");

            aux = new PeriodoPassado(new DateTime(2001, 04, 01));
            Console.WriteLine(aux.StringDataExtenso + "\n");

            aux = new PeriodoPassado(new DateTime(2001, 05, 31));
            Console.WriteLine(aux.StringDataExtenso + "\n");*/
        }

    }
}
