using Common.Domen;
using Common.Transfer;
using Klijent.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent.KontroleriForme.KontroleriUC
{
    public class KontrolerUCPretragaIznajmljivanja
    {
        public UCPretragaIznajmljivanja UCPretragaIznajmljivanja { get; set; }
        internal UserControl NapraviUserControl()
        {
            UCPretragaIznajmljivanja = new UCPretragaIznajmljivanja();
            UCPretragaIznajmljivanja.dataGridView1.DataSource = VratiIznajmljivanja();
            UCPretragaIznajmljivanja.button2.Click += (s, e) => KreirajRacun();
            UCPretragaIznajmljivanja.button1.Click += (s, e) =>
            {
                UCPretragaIznajmljivanja.dataGridView1.DataSource = VratiIznajmljivanjaPoImenuKorisnika();
            };
            UCPretragaIznajmljivanja.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            return UCPretragaIznajmljivanja;
        }

        private void KreirajRacun()
        {
            if (UCPretragaIznajmljivanja.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Sistem ne moze da zapamti racun. Selektujte iznajmljivanje");
                return;
            }else if(UCPretragaIznajmljivanja.dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Sistem ne moze da zapamti racun. Selektujte samo jedno iznajmljivanje");
                return;
            }

            Iznajmljivanje iznajmljivanje = (Iznajmljivanje)UCPretragaIznajmljivanja.dataGridView1.SelectedRows[0].DataBoundItem;

            Racun racun = new Racun
            {
                Iznajmljivanje = iznajmljivanje,
                UkupnaCena = iznajmljivanje.Cena,
                DatumKreiranja = DateTime.Now,
            };

            try
            {
                Odgovor o = Komunikacija.Instance.ZapamtiRacun(racun);
                if (!o.Uspesno)
                {
                    MessageBox.Show($"Sistem ne moze da zapamti racun\n" + o.Greska);
                    return;
                }
                MessageBox.Show("Sistem je uspesno zapamtio racun");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Sistem ne moze da zapamti racun\n" + e.Message);
            }
        }

        private object VratiIznajmljivanjaPoImenuKorisnika()
        {
            List<Iznajmljivanje> lista = null;
            try
            {
                Iznajmljivanje iznajmljivanje = new Iznajmljivanje
                {
                    Korisnik = new Korisnik
                    {
                        ImePrezime = UCPretragaIznajmljivanja.textBox1.Text
                    }
                };
                Odgovor o = Komunikacija.Instance.VratiIznajmljivanjaPoImenuKorisnika(iznajmljivanje);
                if (!o.Uspesno)
                {
                    MessageBox.Show("Sistem ne moze da vrati iznajmljivanja po imenu korisnika\n" + o.Greska);
                }
                lista = (List<Iznajmljivanje>)o.Rezultat;
            }
            catch (Exception e)
            {
                MessageBox.Show("Sistem ne moze da vrati iznajmljivanja po imenu korisnika\n" + e.Message);
            }

            if (lista != null && lista.Count == 0)
            {
                MessageBox.Show("Sistem ne moze da vrati iznajmljivanja po zadatoj vrednosti");
            }
            else
            {
                MessageBox.Show("Sistem je vratio iznajmljivanja po zadatoj vrednosti");
            }

            return lista;
        }

        private List<Iznajmljivanje> VratiIznajmljivanja()
        {
            List<Iznajmljivanje> lista = null;
            try
            {
                Odgovor o = Komunikacija.Instance.VratiIznajmljivanja();
                if (!o.Uspesno)
                {
                    MessageBox.Show("Sistem ne moze da vrati iznajmljivanja\n" + o.Greska);
                }
                lista = (List<Iznajmljivanje>)o.Rezultat;
            }
            catch (Exception e)
            {
                MessageBox.Show("Sistem ne moze da vrati iznajmljivanja\n" + e.Message);
            }
            return lista;
        }
    }
}
