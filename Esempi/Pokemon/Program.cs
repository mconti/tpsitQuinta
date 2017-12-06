using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    enum Nome  { No, Charizard, Squirtle, Bulbasaur, anna }
    enum Tipo  { No, fuoco, acqua, erba }


    class Program
    {
        static void Main(string[] args)
        {
            //poke p = new poke();
            poke p = new poke(Nome.Bulbasaur, Tipo.erba);

            Console.WriteLine(p.ToString());
            Console.WriteLine("anna1".Palindromo());
            Console.WriteLine("anna".Palindromo());
            Console.WriteLine("Anna".Palindromo());
            Console.ReadKey();
        }
    }
}
