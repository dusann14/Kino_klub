using Common.Domen;
using Common.Transfer;
using Klijent.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent.KontroleriForme.KontroleriUC
{
    public class KontrolerUCOcena
    {
        public UCOcene UCOcene { get; set; }
        internal UserControl NapraviUserControl()
        {
            UCOcene = new UCOcene();
            UCOcene.dataGridView1.DataSource = VratiFilmove();
            UCOcene.button2.Click += (s, e) => OceniFilm();
            UCOcene.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UCOcene.textBox3.Validating += TextBox3_Validating;
            return UCOcene;
        }


        private void TextBox3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(UCOcene.textBox3.Text) || !new Regex(@"\b([1-9]|10)\b").IsMatch(UCOcene.textBox3.Text))
            {
                e.Cancel = true;
                UCOcene.errorProvider1.SetError(UCOcene.textBox3, "Ocena mora biti od 1 do 10");
            }
            else
            {
                e.Cancel = false;
                UCOcene.errorProvider1.SetError(UCOcene.textBox3, null);
            }
        }

        private void OceniFilm()
        {
            if (string.IsNullOrEmpty(UCOcene.textBox3.Text))
            {
                MessageBox.Show("Sistem ne moze da oceni film, niste uneli ocenu");
                return;
            }

            if(UCOcene.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Sistem ne moze da oceni film, niste selektovali film");
                return;
            }

            if (UCOcene.dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Sistem ne moze da oceni film, selektujte samo jedan film");
                return;
            }

            Ocena ocena = new Ocena
            {
                Film = (Film)UCOcene.dataGridView1.SelectedRows[0].DataBoundItem,
                Korisnik = Session.Instance.Korisnik,
                OcenaBroj = Int32.Parse(UCOcene.textBox3.Text)
            };

            try
            {
                Odgovor o = Komunikacija.Instance.OceniFilm(ocena);
                if (!o.Uspesno)
                {
                    MessageBox.Show("Sistem ne moze da oceni film\n" + o.Greska);
                }
                MessageBox.Show("Sistem je ocenio film");
            }
            catch(Exception e)
            {
                MessageBox.Show("Sistem ne moze da oceni film\n" + e.Message);
                return;
            }

        }

        private List<Film> VratiFilmove()
        {
            List<Film> listaFilmova = null;
            List<Ocena> listaOcena = null;

            try
            {
                Odgovor o = Komunikacija.Instance.VratiFilmove();
                if (!o.Uspesno)
                {
                    MessageBox.Show("Sistem ne moze da vrati filmove\n" + o.Greska);
                }
                listaFilmova = (List<Film>)o.Rezultat;                         
            }
            catch (Exception e)
            {
                MessageBox.Show("Sistem ne moze da vrati filmove\n" + e.Message);
            }

            try
            {
                Odgovor o = Komunikacija.Instance.VratiOcene();
                if (!o.Uspesno)
                {
                    MessageBox.Show("Sistem ne moze da vrati ocene filmova\n" + o.Greska);
                }
                listaOcena = (List<Ocena>)o.Rezultat;
            }
            catch (Exception e1)
            {
                MessageBox.Show("Sistem ne moze da vrati ocene filmova\n" + e1.Message);
            }

            if (listaFilmova != null && listaOcena != null)
            {
                foreach (Film film in listaFilmova)
                {
                    double prosecnaOcena = 0;
                    int br = 0;
                    foreach (Ocena ocena in listaOcena)
                    {
                        if (ocena.Film.Id == film.Id)
                        {
                            prosecnaOcena += ocena.OcenaBroj;
                            br++;
                        }
                    }
                    film.ProsecnaOcena = prosecnaOcena / br;
                }
            }

            return listaFilmova;
        }
    }
}
