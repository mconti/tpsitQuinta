using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conti.maurizio._5H.HelloLINQ
{
    public class Persona
    {
        // Tip!
        // C# 7.0 consente un nuovo tipo di property.
        // Si possono fare i field interni privati ... 
        private String _nome;
        private String _cognome;
        private DateTime _data = DateTime.Now;

        // ...e dichiarare in modo veloce l'accessor.
        public string Nome { get => _nome; set => _nome = value; }
        public string Cognome { get => _cognome; set => _cognome = value; }
        public DateTime Data { get => _data; set => _data = value; }

        public Persona()
        {
            // Tip!
            // Costruttore di default.
            // Detto anche costruttore vuoto.
            //
            // Indispensabile per garantire la sequenza 
            // di inizializzazione delle variabili interne alla classe.
        }
        public Persona(int val)
        {
            // Genera una Persona partendo da un numero.
            // Serve per popolare la base dati con dei valori a caso...
            
            // Ad esempio
            // Nome1, Cognome1, 2/2/2013
            // Nome2, Cognome2, 2/3/2017
            // ...
            Nome = "Nome" + val.ToString();
            Cognome = "Cognome" + val.ToString();
            Data = DateTime.Now.Subtract(TimeSpan.FromDays(val++ * 200).Add(TimeSpan.FromHours(val * 22)));
        }

        public Persona(string riga)
        {
            // Tip!
            // Se le colonne sono sbagliate è giusto sollevare 
            // eccezioni che verranno poi gestite dal chiamante...
            string[] colonne = riga.Split(';');
            Nome = colonne[0];
            Cognome = colonne[1];
            DateTime.TryParse(colonne[2], out _data);
        }


        public override string ToString() => $"Io sono {Nome} {Cognome} e sono nato il {Data.ToLongDateString()}";
    }

    public class Persone : ObservableCollection<Persona>
    {
        // Tip!
        // Ci rifacciamo sul costruttore Persone(int)
        public Persone()
            : this(10)  
        {
        }

        public Persone(int quante)
        {
            while (quante-- > 0)
            {
                Add(new Persona(quante));
            }
        }
        public Persone(string NomeFile)
        {
            // Tip!
            // Se non trovo il file, 
            // è giusto propagare l'eccezione ai "piani alti".
            // Quindi qui, NO try catch !!
            StreamReader rd = new StreamReader(NomeFile);
            rd.ReadLine();
            while (!rd.EndOfStream)
            {
                Add(new Persona(rd.ReadLine()));
            }
        }

        public void SalvaCSV(string nomeFile)
        {
            StreamWriter wr = new StreamWriter(nomeFile);
            wr.WriteLine("Nome;Cognome;Data");

            foreach (Persona p in this)
            {   // Tip!
                // Da C#6.0 esistono le stringhe interpolate...
                // Usatele, sono molto comode.
                wr.WriteLine($"{p.Nome};{p.Cognome};{p.Data}");
            }
            wr.Close();
        }
    }
}
