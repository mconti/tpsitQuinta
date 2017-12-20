using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows;
using System.Web.Hosting;

namespace WebApplication1
{
    public enum TipoProdotto { Vuoto, Caffetteria, Torta }
    public enum NomeCaffetteria { Vuoto, Caffe, Cappuccio, Pasta }
    public enum NomeTorta { Vuoto, Sacker, Mimosa, Frutta }

    public class Prodotto
    {
        public TipoProdotto Tipo;
        public Prodotto()
        {
            Tipo = TipoProdotto.Vuoto;
        }

        public Prodotto(string t)
        {
            bool valido = Enum.TryParse<TipoProdotto>(t, out Tipo);
            if (valido)
            {
                Tipo = (TipoProdotto)Enum.Parse(typeof(TipoProdotto), t);
            }
        }

        public virtual int StampaPrezzo()
        {
            return 0;
        }

        public TipoProdotto Tipologia
        {
            get { return Tipo; }
        }
    }

    public class Caffetteria : Prodotto
    {
        public NomeCaffetteria NomeTipo;
        public int prezzo { get; set; }
        public Caffetteria() { }

        public Caffetteria(string T, string _NomeCaffetteria, string p) : base(T)
        {
            bool valido = Enum.TryParse<NomeCaffetteria>(_NomeCaffetteria, out NomeTipo);
            if (valido)
            {
                NomeTipo = (NomeCaffetteria)Enum.Parse(typeof(NomeCaffetteria), _NomeCaffetteria);
            }
            prezzo = Convert.ToInt32(p);
        }

        public NomeCaffetteria TipoCaff
        {
            get { return NomeTipo; }
        }

    }

    public class Torta : Prodotto
    {
        public int peso { get; set; }

        public NomeTorta NomeTipo;
        public int prezzo { get; set; }

        public Torta() { }

        public Torta(string T, string _NomeTorta, string _prezzo, string _peso) : base(T)
        {
            peso = Convert.ToInt32(_peso);
            bool valido = Enum.TryParse<NomeTorta>(_NomeTorta, out NomeTipo);
            if (valido)
            {
                NomeTipo = (NomeTorta)Enum.Parse(typeof(NomeTorta), _NomeTorta);
            }
            prezzo = Convert.ToInt32(_prezzo);
        }

        public override int StampaPrezzo()
        {
            return prezzo * peso;
        }

        public NomeTorta TipoTorta
        {
            get { return NomeTipo; }
        }
    }

    public class Prodotti : ObservableCollection<Prodotto>
    {
        public Prodotti() { }
        public Prodotti(string percorso)
        {
            string nomeFile = HostingEnvironment.MapPath(@"~/App_Data/FileDati.txt");

            StreamReader file = new StreamReader(nomeFile);
            while (!file.EndOfStream)
            {
                string str = file.ReadLine();
                string[] riga = str.Split(',');
                if (riga[0] == "Caffetteria")
                {
                    
                    Add(new Caffetteria(riga[0], riga[1], riga[2]));
                }
                if (riga[0] == "Torta")
                {
                    Add(new Torta(riga[0], riga[1], riga[2], riga[3]));
                }
            }
        }

    }
}
