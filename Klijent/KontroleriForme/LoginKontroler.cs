using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using System.Windows.Forms;
using Common.Domen;
using Common.Transfer;
using System.Net.Sockets;

namespace Klijent.KontroleriForme
{
    public class LoginKontroler
    {
        public Login Forma { get; set; }

        public Login NapraviLoginFormu()
        {
            Forma = new Login();
            Forma.StartPosition = FormStartPosition.CenterScreen;
            Forma.comboBox1.DataSource = VratiUloge();
            Forma.button1.Click += Button1_Click;
            return Forma;
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

        private void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Forma.textBox1.Text) || string.IsNullOrEmpty(Forma.textBox2.Text))
            {
                MessageBox.Show("Niste uneli korisnicko ime ili lozinku");
                return;
            }

            Korisnik korisnik = new Korisnik
            {
                KorisnickoIme = Forma.textBox1.Text,
                Lozinka = Forma.textBox2.Text,
                Uloga = (Uloga)Forma.comboBox1.SelectedItem
            };

            Odgovor odgovor;

            try
            {
                odgovor = Komunikacija.Instance.PrijaviSe(korisnik);

                if (!odgovor.Uspesno)
                {
                    MessageBox.Show($"Sistem ne moze da prijavi korisnika\n" + odgovor.Greska);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
                return;
            }

            Korisnik k = (Korisnik)odgovor.Rezultat;

            if (k == null)
            {
                MessageBox.Show("Ne postoji korisnik sa unetim kredencijalima");
                return;
            }

            Session.Instance.Korisnik = k;
            MessageBox.Show("Uspesno ste se prijavili na sistem");
            Forma.Dispose();
            Koordinator.Instance.OtvoriGlavnuFormu();
        }
    }
}
