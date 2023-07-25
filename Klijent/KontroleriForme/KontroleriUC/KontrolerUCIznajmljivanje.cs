using Common.Domen;
using Common.Transfer;
using Klijent.UserControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent.KontroleriForme.KontroleriUC
{
    public class KontrolerUCIznajmljivanje
    {
        public UCKreiranjeIznajmljivanja UCKreiranjeIznajmljivanja { get; set; }

        private List<Film> dodatiFilmovi = new List<Film>();
        private double ukupnaCena;
        private int brojDana;
        internal UserControl NapraviUserControl()
        {
            UCKreiranjeIznajmljivanja = new UCKreiranjeIznajmljivanja();
            UCKreiranjeIznajmljivanja.textBox1.Text = Session.Instance.Korisnik.ImePrezime;
            UCKreiranjeIznajmljivanja.textBox2.Text = DateTime.Now.ToShortDateString();
            UCKreiranjeIznajmljivanja.dataGridView1.DataSource = VratiFilmove();
            UCKreiranjeIznajmljivanja.dataGridView1.Columns[5].Visible = false;
            UCKreiranjeIznajmljivanja.button1.Click += (s, e) => Izracunaj();
            UCKreiranjeIznajmljivanja.button2.Click += (s, e) => ZapamtiIznajmljivanje();
            return UCKreiranjeIznajmljivanja;
        }

        private void ZapamtiIznajmljivanje()
        {
            Iznajmljivanje iznajmljivanje = new Iznajmljivanje
            {
                Korisnik = Session.Instance.Korisnik,
                DatumIznajmljivanja = DateTime.Now,
                DatumTrajanja = UCKreiranjeIznajmljivanja.dateTimePicker1.Value,
                Dani = brojDana,
                Cena = ukupnaCena,
                Filmovi = dodatiFilmovi
            };

            try
            {
                Odgovor o = Komunikacija.Instance.ZapamtiIznajmljivanje(iznajmljivanje);
                if (!o.Uspesno)
                {
                    MessageBox.Show("Sistem ne moze da zapamti iznajmljivanje\n" + o.Greska);
                    return;
                }
                MessageBox.Show("Sistem je uspesno zapamtio iznajmljivanje\n" + o.Greska);
            }
            catch (Exception e)
            {
                MessageBox.Show("Sistem ne moze da zapamti iznajmljivanje\n" + e.Message);
            }
        }

        private void Izracunaj()
        {
            if(UCKreiranjeIznajmljivanja.dateTimePicker1.Value < DateTime.Now)
            {
                MessageBox.Show("Datum mora biti u buducnosti");
                return;
            }else if(UCKreiranjeIznajmljivanja.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Dodajte filmove u iznajmljivanje");
                return;
            }

            brojDana = (UCKreiranjeIznajmljivanja.dateTimePicker1.Value - DateTime.Now).Days;
            UCKreiranjeIznajmljivanja.textBox4.Text = $"{brojDana}";

            ukupnaCena = 0;

            foreach (DataGridViewRow red in UCKreiranjeIznajmljivanja.dataGridView1.SelectedRows)
            {
                Film film = (Film)red.DataBoundItem;
                if (!dodatiFilmovi.Contains(film))
                {
                    dodatiFilmovi.Add(film);
                }

                ukupnaCena += brojDana * film.CenaPoDanu;
            }
            UCKreiranjeIznajmljivanja.textBox5.Text = $"{ukupnaCena}";
        }

        private List<Film> VratiFilmove()
        {
            List<Film> lista = null;
            try
            {
                Odgovor o = Komunikacija.Instance.VratiFilmove();
                if (!o.Uspesno)
                {
                    MessageBox.Show("Sistem ne moze da vrati filmove\n" + o.Greska);
                }
                lista = (List<Film>)o.Rezultat;
            }
            catch (Exception e)
            {
                MessageBox.Show("Sistem ne moze da vrati filmove\n" + e.Message);
            }
            return lista;
        }
    }
}
