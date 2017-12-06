using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    class poke
    {
        public Nome nome { get; set; }
        public Tipo tipo { get; set; }

        public poke() {}

        public poke(Nome n, Tipo t)
        {
            nome = n;
            tipo = t;
        }

        public override string ToString()
        {
            return nome + " " + tipo;
        }
    }

    public static class MiaString
    {
        public static string Palindromo( this string valore )
        {
            return (valore.ToLower() == new string( valore.ToLower().Reverse().ToArray())) ? "Si" : "No";
        }
    }

}
