using Klijent.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent.KontroleriForme
{
    public class KontrolerForme
    {
        public Klijent Forma { get; set; }

        public UserControl OtvorenaUC { get; set; } = new UCDodavanjeFilma();
        internal Klijent NapraviGlavnuFormu()
        {
            Forma = new Klijent();
            PodesiMeni();
            Forma.FormBorderStyle = FormBorderStyle.Sizable;
            Forma.StartPosition = FormStartPosition.CenterScreen;
            Forma.FormClosed += OdjaviSe;
            Forma.osvezavanjeToolStripMenuItem.Click += OsvezavanjeToolStripMenuItem_Click;
            Forma.korisnikToolStripMenuItem.Click += (s, e) =>
            {
                OtvorenaUC = new UCKorisnik();
                Koordinator.Instance.OtvoriUCKorisnik();
            };
            Forma.pretragaFilmovaToolStripMenuItem.Click += (s, e) =>
            {
                OtvorenaUC = new UCPretragaFilmova();
                Koordinator.Instance.OtvoriUCPretragaFilmova();
            };
            Forma.filmToolStripMenuItem.Click += (s, e) =>
            {
                OtvorenaUC = new UCDodavanjeFilma();
                Koordinator.Instance.OtvoriUCDodavanjeFilma();
            };
            Forma.iznajmljivanjeToolStripMenuItem.Click += (s, e) =>
            {
                OtvorenaUC = new UCKreiranjeIznajmljivanja();
                Koordinator.Instance.OtvoriUCIznajmljivanje();
            };
            Forma.pretragaIznajmljivanjaToolStripMenuItem.Click += (s, e) =>
            {
                OtvorenaUC = new UCPretragaIznajmljivanja();
                Koordinator.Instance.OtvoriUCPretragaIznajmljivanja();
            };
            Forma.oceneToolStripMenuItem.Click += (s, e) =>
            {
                OtvorenaUC = new UCOcene();
                Koordinator.Instance.OtvoriUCOcene();
            };

            return Forma;
        }

        private void PodesiMeni()
        {
            if(Session.Instance.Korisnik.Uloga.Id == 1)
            {
                Forma.iznajmljivanjeToolStripMenuItem.Visible = false;
                Forma.oceneToolStripMenuItem.Visible = false;
            }
            else
            {
                Forma.filmToolStripMenuItem.Visible = false;
                Forma.pretragaIznajmljivanjaToolStripMenuItem.Visible = false;
                Forma.korisnikToolStripMenuItem.Visible = false;
            }
        }

        private void OsvezavanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(OtvorenaUC is UCDodavanjeFilma)
            {
                Koordinator.Instance.OtvoriUCDodavanjeFilma();
            }else if(OtvorenaUC is UCPretragaFilmova)
            {
                Koordinator.Instance.OtvoriUCPretragaFilmova();
            }else if(OtvorenaUC is UCKreiranjeIznajmljivanja)
            {
                Koordinator.Instance.OtvoriUCIznajmljivanje();
            }else if(OtvorenaUC is UCPretragaIznajmljivanja)
            {
                Koordinator.Instance.OtvoriUCPretragaIznajmljivanja();
            }else if(OtvorenaUC is UCOcene)
            {
                Koordinator.Instance.OtvoriUCOcene();
            }else if(OtvorenaUC is UCKorisnik)
            {
                Koordinator.Instance.OtvoriUCKorisnik();
            }
        }

        internal void OdjaviSe(object sender, FormClosedEventArgs e)
        {
            try
            {
                Komunikacija.Instance.OdjaviSe();
                MessageBox.Show("Uspesno ste se odjavili");
                Forma.Dispose();
                Koordinator.Instance.OtvoriLoginFormu();
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
            }
        }
    }
}
