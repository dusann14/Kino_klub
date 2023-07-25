using Klijent.KontroleriForme;
using Klijent.KontroleriForme.KontroleriUC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent
{
    //koordinator
    public class Koordinator
    {
        public Klijent KlijentForma { get; set; }

        public Login LoginForma { get; set; }

        private static Koordinator instance;
        public static Koordinator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Koordinator();
                }
                return instance;
            }

        }

        private Koordinator()
        {
            loginKontroler = new LoginKontroler();
            kontrolerForme = new KontrolerForme();
            kontrolerUCDodavanjeFilma = new KontrolerUCDodavanjeFilma();
            kontrolerUCPretragaFilmova = new KontrolerUCPretragaFilmova();
            kontrolerUCIznajmljivanje = new KontrolerUCIznajmljivanje();
            kontrolerUCPretragaIznajmljivanja = new KontrolerUCPretragaIznajmljivanja();
            kontrolerUCOcena = new KontrolerUCOcena();
            kontrolerUCKorisnik = new KontrolerUCKorisnik();
        }

        private LoginKontroler loginKontroler;
        private KontrolerForme kontrolerForme;
        private KontrolerUCDodavanjeFilma kontrolerUCDodavanjeFilma;
        private KontrolerUCPretragaFilmova kontrolerUCPretragaFilmova;
        private KontrolerUCIznajmljivanje kontrolerUCIznajmljivanje;
        private KontrolerUCPretragaIznajmljivanja kontrolerUCPretragaIznajmljivanja;
        private KontrolerUCOcena kontrolerUCOcena;
        private KontrolerUCKorisnik kontrolerUCKorisnik;

        internal void OtvoriLoginFormu()
        {
            try
            {
                Komunikacija.Instance.PoveziSe();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne moze da se poveze na server" + ex.Message);
                return;
            }
            
            LoginForma = loginKontroler.NapraviLoginFormu();
            LoginForma.ShowDialog();
        }

        internal void OtvoriGlavnuFormu()
        {
            KlijentForma = kontrolerForme.NapraviGlavnuFormu();

            if (Session.Instance.Korisnik.Uloga.Id == 1)
            {
                OtvoriUCDodavanjeFilma();
            }
            else
            {
                OtvoriUCIznajmljivanje();
            }

            KlijentForma.ShowDialog();
        }

        internal void OtvoriUCDodavanjeFilma()
        {
            KlijentForma.PostaviPanel(kontrolerUCDodavanjeFilma.NapraviUserControl());
        }

        internal void OtvoriUCPretragaFilmova()
        {
            KlijentForma.PostaviPanel(kontrolerUCPretragaFilmova.NapraviUserControl());
        }

        internal void OtvoriUCIznajmljivanje()
        {
            KlijentForma.PostaviPanel(kontrolerUCIznajmljivanje.NapraviUserControl());
        }

        internal void OtvoriUCPretragaIznajmljivanja()
        {
            KlijentForma.PostaviPanel(kontrolerUCPretragaIznajmljivanja.NapraviUserControl());
        }

        internal void OtvoriUCOcene()
        {

            KlijentForma.PostaviPanel(kontrolerUCOcena.NapraviUserControl());
        }

        internal void OtvoriUCKorisnik()
        {
            KlijentForma.PostaviPanel(kontrolerUCKorisnik.NapraviUserControl());
        }
    }
}
