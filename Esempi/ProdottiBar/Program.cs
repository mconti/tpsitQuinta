using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProdottiBar
{
    class Program
    {
        static void Main(string[] args)
        {
            stampaListino("listino.txt");

            ListaProdotti ls = new ListaProdotti("listino.txt");
            Console.WriteLine(ls.stampa());
            ListaProdotti conto = new ListaProdotti();

            while (true) { 
            
                Console.WriteLine("Cosa Vuoi");
                prodotto p = ls.dammi(Console.ReadLine());

                double peso = 0;
                if (p.pt == prodottoType.Torte)
                {
                    Console.WriteLine("Quanto ne vuoi?");
                    peso = Convert.ToDouble(Console.ReadLine());
                }
                conto.aggiungi(peso, p);

                Console.WriteLine("Ecco il tuo ordine\n"+conto.stampa());
                Console.WriteLine("Il tuo conto e:" + conto.contoTot());

                Console.WriteLine();
            }
        }

        public static void stampaListino(string nomeOutput)
        {
            StreamWriter sw = new StreamWriter(nomeOutput);
            Random r = new Random();
            
            foreach (var v in Enum.GetValues(typeof(prodottoType)))
            {
                string linea = "";
                linea += v.ToString()+";";
                if (v.ToString() == "Caffetteria") {

                    foreach (var l in Enum.GetValues(typeof(caffetteriaType)))
                    {
                        linea += l.ToString()+";"+r.Next(0,30);
                        sw.WriteLine(linea);
                        linea = "";
                        linea += v.ToString() + ";";
                    }
                    
                }
                if (v.ToString() == "Torte")
                {
                    foreach (var l in Enum.GetValues(typeof(tortaType)))
                    {
                        linea += l.ToString() + ";" + r.Next(0, 30);
                        sw.WriteLine(linea);
                        linea = "";
                        linea += v.ToString() + ";";
                    }
                  
                }

            }
 
            sw.Close();

        }

    }
}
