using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProdottiBar
{
    public enum prodottoType { Caffetteria = 1, Torte }
    public enum caffetteriaType { Caffe = 1, Cappuccio, Torta }
    public enum tortaType { Sacker = 1, Carote, Frutta }
   
    public class prodotto
    {
        public prodottoType pt { get; set; }

        public prodotto() { }

        public virtual double prezzo() {
            return 0;
        }
        public virtual string info()
        {
            return pt.ToString()+"\n";
        }

    }

    public class Caffetteria : prodotto {

        public caffetteriaType ct { get; set; }
        public double p { get; set; }

        public Caffetteria() {

        }

        public Caffetteria(string s)
        {
            string[] dati = s.Split(';');
            pt = prodottoType.Caffetteria;
            ct = (caffetteriaType)Enum.Parse(typeof(caffetteriaType), dati[1]);
            p = Convert.ToDouble(dati[2]);
        }

        public override double prezzo()
        {
            return p;
        }
        public override string info()
        {
            return pt.ToString() + ";" + ct.ToString() + ";" + p + "\n";
        }

    }

    public class Torte : prodotto {
        public tortaType tt { get; set; }
        public double pKg { get; set; }
        public double peso { get; set; }

        public Torte() {

        }
        public Torte(string s){

            string[] dati = s.Split(';');
            try
            {
                pt = prodottoType.Torte;
                tt = (tortaType)Enum.Parse(typeof(tortaType), dati[1]);
                pKg= Convert.ToDouble(dati[2]);
            }
            catch { }


        }
        public override double prezzo()
        {
            return pKg*peso;
        }
        public override string info()
        {
            return pt.ToString() + ";" + tt.ToString() + ";" + pKg + ";" + peso + "\n";
        }


    }

    public class ListaProdotti : List<prodotto> {

        public ListaProdotti() {

        }
        public ListaProdotti(string fileInput)
        {
            StreamReader sr = new StreamReader(fileInput);
            while (!sr.EndOfStream) {
                string linea = sr.ReadLine();
                string[] info = linea.Split(';');

                // Factory
                // Si guarda alla prima colonna e si decide il tipo di oggetto
                prodottoType p = (prodottoType)Enum.Parse(typeof(prodottoType),info[0]);
                if (p == prodottoType.Caffetteria)
                    Add(new Caffetteria(linea));
                else
                    Add(new Torte(linea));
            }
            sr.Close();
        }
        public double contoTot() {
            double tot= 0;
            foreach (prodotto p in this) {
                tot += p.prezzo();
            }
            return tot;
        }
        public prodotto dammi(string s) {

            // Se ciò che ha scritto l'utente
            // esiste nell'insieme dei nomi dell'Enum caffetteriaType allora entra
            if (Enum.IsDefined(typeof(caffetteriaType), s)) {

                var soloCaffetteria = 
                    from p in this
                    where p.pt == prodottoType.Caffetteria
                    select p;

                foreach (Caffetteria c in soloCaffetteria)
                {
                    if (c.ct.ToString() == s) {
                        return c;
                    }
                }
            }

            // Se ciò che ha scritto l'utente
            // esiste nell'insieme dei nomi dell'Enum tortaType allora entra
            if (Enum.IsDefined(typeof(tortaType), s))
            {
                var soloLeTorte = 
                    from p in this
                    where p.pt == prodottoType.Torte
                    select p;

                foreach (Torte c in soloLeTorte)
                {
                    if (c.tt.ToString() == s)
                    {
                        return c;
                    }
                }
            }
            return null;
        }

        public void aggiungi(double Peso_, prodotto p)
        {
            Torte t = p as Torte;
            if( t != null )
            {
                t.peso = Peso_;
                Add(t);
            }
            else
            {
                Add(p);
            }

        }

        public string stampa()
        {
            string ritorna = "";

            foreach (prodotto p in this)
            {
                ritorna += p.info();
            }
            return ritorna;
        }
    }
}
