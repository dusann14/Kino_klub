using Common.Domen;
using Common.Transfer;
using Klijent.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent.KontroleriForme.KontroleriUC
{
    public class KontrolerUCKorisnik
    {
        public UCKorisnik UCKorisnik { get; set; }

        internal UserControl NapraviUserControl()
        {
            UCKorisnik = new UCKorisnik();
            UCKorisnik.button1.Click += (s, e) => ZapamtiKorisnika();
            UCKorisnik.comboBox1.DataSource = VratiUloge();
            UCKorisnik.textBox1.Validating += TextBox1_Validating;
            UCKorisnik.textBox2.Validating += TextBox2_Validating;
            UCKorisnik.textBox3.Validating += TextBox3_Validating;
            return UCKorisnik;
        }

        private List<Uloga> VratiUloge()
        {
            try
            {
                Odgovor odgovor = Komunikacija.Instance.VratiUloge();

                if (!odgovor.Uspesno)
                {
                    MessageBox.Show($"Sistem ne moze da vrati uloge\n" + odgovor.Greska);
                    return null;
                }

                return (List<Uloga>)odgovor.Rezultat;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
                return null;
            }

        }

        private void TextBox3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(UCKorisnik.textBox3.Text))
            {
                e.Cancel = true;
                UCKorisnik.errorProvider1.SetError(UCKorisnik.textBox3, "Niste uneli lozinku");
            }
            else
            {
                e.Cancel = false;
                UCKorisnik.errorProvider1.SetError(UCKorisnik.textBox3, null);
            }
        }

        private void TextBox2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(UCKorisnik.textBox2.Text))
            {
                e.Cancel = true;
                UCKorisnik.errorProvider1.SetError(UCKorisnik.textBox2, "Niste uneli korisnicko ime");
            }
            else
            {
                e.Cancel = false;
                UCKorisnik.errorProvider1.SetError(UCKorisnik.textBox2, null);
            }
        }

        private void TextBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(UCKorisnik.textBox1.Text))
            {
                e.Cancel = true;
                UCKorisnik.errorProvider1.SetError(UCKorisnik.textBox1, "Niste uneli ime i prezime");
            }
            else
            {
                e.Cancel = false;
                UCKorisnik.errorProvider1.SetError(UCKorisnik.textBox1, null);
            }
        }

        private void ZapamtiKorisnika()
        {
            if (UCKorisnik.dateTimePicker1.Value > DateTime.Now)
            {
                MessageBox.Show("Datum mora biti u proslosti");
                return;
            }

            Korisnik korisnik = new Korisnik
            {
                ImePrezime = UCKorisnik.textBox1.Text,
                KorisnickoIme = UCKorisnik.textBox2.Text,
                Lozinka = UCKorisnik.textBox3.Text,
                DatumRodjenja = UCKorisnik.dateTimePicker1.Value,
                Uloga = (Uloga)UCKorisnik.comboBox1.SelectedItem
            };

            try
            {
                Odgovor o = Komunikacija.Instance.ZapamtiKorisnika(korisnik);
                if (!o.Uspesno)
                {
                    MessageBox.Show("Sistem ne moze da zapamti korisnika " + o.Greska);
                    return;
                }
                MessageBox.Show("Sistem je uspesno zapamtio korisnika");
            }catch(Exception e)
            {
                MessageBox.Show("Sistem ne moze da zapamti korisnika " + e.Message);
            }

        }
    }
}
