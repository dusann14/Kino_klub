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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Klijent.KontroleriForme.KontroleriUC
{
    public class KontrolerUCDodavanjeFilma
    {
        public UCDodavanjeFilma UCDodavanjeFilma { get; set; }

        private BindingList<Zanr> dodatiZanrovi = new BindingList<Zanr>();
        internal UserControl NapraviUserControl()
        {
            UCDodavanjeFilma = new UCDodavanjeFilma();
            UCDodavanjeFilma.comboBox1.DataSource = VratiReditelje();
            UCDodavanjeFilma.comboBox2.DataSource = VratiZanrove();
            UCDodavanjeFilma.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UCDodavanjeFilma.textBox3.Validating += TextBox3_Validating;
            UCDodavanjeFilma.button1.Click += (s, e) => DodajZanr();
            UCDodavanjeFilma.button2.Click += (s, e) => ObrisiZanr();
            UCDodavanjeFilma.button3.Click += (s, e) => SacuvajFilm();
            return UCDodavanjeFilma;
        }

        private void SacuvajFilm()
        {
            if(dodatiZanrovi.Count == 0)
            {
                MessageBox.Show("Sistem ne moze da zapamti film. Film mora imati neki zanr");
                return;
            }

            Film film = new Film
            {
                Naziv = UCDodavanjeFilma.textBox1.Text,
                DuzinaTrajanja = UCDodavanjeFilma.textBox2.Text,
                CenaPoDanu = Convert.ToDouble(UCDodavanjeFilma.textBox3.Text),
                Datum = DateTime.Now,
                Reditelj = (Reditelj)UCDodavanjeFilma.comboBox1.SelectedItem,
                Zanrovi = dodatiZanrovi.ToList()
            };

            try
            {
                Odgovor o = Komunikacija.Instance.ZapamtiFilm(film);
                if (!o.Uspesno)
                {
                    MessageBox.Show($"Sistem ne moze da zapamti film\n" + o.Greska);
                    return;
                }
                MessageBox.Show("Sistem je uspesno zapamtio film");
            }
            catch(Exception e)
            {
                MessageBox.Show($"Sistem ne moze da zapamti film\n" + e.Message);
            }
            dodatiZanrovi = new BindingList<Zanr>();
        }

        private void ObrisiZanr()
        {
            dodatiZanrovi.Remove((Zanr)UCDodavanjeFilma.comboBox2.SelectedItem);
            UCDodavanjeFilma.dataGridView1.DataSource = dodatiZanrovi;
        }

        private void DodajZanr()
        {
            dodatiZanrovi.Add((Zanr)UCDodavanjeFilma.comboBox2.SelectedItem);
            UCDodavanjeFilma.dataGridView1.DataSource = dodatiZanrovi;
        }

        private void TextBox3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(UCDodavanjeFilma.textBox3.Text) || !new Regex(@"^-?[0-9][0-9,\.]+$").IsMatch(UCDodavanjeFilma.textBox3.Text))
            {
                e.Cancel = true;
                UCDodavanjeFilma.errorProvider1.SetError(UCDodavanjeFilma.textBox3, "Cena mora da sadrzi brojeve");
            }
            else
            {
                e.Cancel = false;
                UCDodavanjeFilma.errorProvider1.SetError(UCDodavanjeFilma.textBox3, null);
            }
        }

        private List<Zanr> VratiZanrove()
        {
            List<Zanr> lista = null;
            Odgovor o;
            try
            {
                o = Komunikacija.Instance.VratiZanrove();              
                if (!o.Uspesno)
                {
                    MessageBox.Show($"Sistem ne moze da vrati zanrove\n" + o.Greska);
                    return null;
                }
                lista = (List<Zanr>)o.Rezultat;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Sistem ne moze da vrati zanrove\n" + e.Message);
            }
            return lista;
        }

        private List<Reditelj> VratiReditelje()
        {
            List<Reditelj> lista = null;
            Odgovor o;
            try
            {
                o = Komunikacija.Instance.VratiReditelje();
                if (!o.Uspesno)
                {
                    MessageBox.Show($"Sistem ne moze da vrati reditelje\n" + o.Greska);
                    return null;
                }
                lista = (List<Reditelj>)o.Rezultat;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Sistem ne moze da vrati reditelje\n" + e.Message);
            }
            return lista;
        }
    }
}
