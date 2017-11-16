using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Persona
    {
        private String _nome;
        private String _cognome;
        private DateTime _data;

        public Persona() {
        }
        public Persona(int val)
        {
            Nome = "Nome" + val.ToString();
            Cognome = "Cognome" + val.ToString();
            Data = DateTime.Now.Subtract(TimeSpan.FromDays(val++ * 200).Add(TimeSpan.FromHours(val*22)));
        }

        public Persona( string riga )
        {
            string[] colonne = riga.Split(';');
            Nome = colonne[0];
            Cognome = colonne[1];
            DateTime.TryParse(colonne[2], out _data);
        }

        public string Nome { get => _nome; set => _nome = value; }
        public string Cognome { get => _cognome; set => _cognome = value; }
        public DateTime Data { get => _data; set => _data = value; }

        public override string ToString() => $"Io sono {Nome} {Cognome} e sono nato il {Data.ToLongDateString()}";
    }

    public class Persone : ObservableCollection<Persona>
    {
        public Persone()
            : this(10)
        {
        }

        public Persone(int quante)
        {
            while(quante-- >0)
            {
                Add(new Persona(quante));
            }
        }
        public Persone(string NomeFile)
        {
            StreamReader rd = new StreamReader(NomeFile);
            rd.ReadLine();
            while(!rd.EndOfStream)
            {
                Add(new Persona(rd.ReadLine()));
            }
        }

        public void SalvaCSV( string nomeFile)
        {
            StreamWriter wr = new StreamWriter(nomeFile);
            wr.WriteLine("Nome;Cognome;Data");

            foreach(Persona p in this)
            {
                wr.WriteLine($"{p.Nome};{p.Cognome};{p.Data}");
            }
            wr.Close();
        }

    }
}
