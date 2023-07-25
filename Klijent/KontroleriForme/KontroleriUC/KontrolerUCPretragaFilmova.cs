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
    public class KontrolerUCPretragaFilmova
    {
        public UCPretragaFilmova UCPretragaFilmova { get; set; }

        internal UserControl NapraviUserControl()
        {
            UCPretragaFilmova = new UCPretragaFilmova();
            UCPretragaFilmova.dataGridView1.DataSource = VratiFilmove();
            UCPretragaFilmova.dataGridView1.Columns[5].Visible = false;
            UCPretragaFilmova.button1.Click += (s, e) =>
            {
                UCPretragaFilmova.dataGridView1.DataSource = VratiFilmovePoNazivu();
            };
            UCPretragaFilmova.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            return UCPretragaFilmova;
        }

        private List<Film> VratiFilmovePoNazivu()
        {
            List<Film> lista = null;
            try
            {
                Film film = new Film
                {
                    Naziv = UCPretragaFilmova.textBox1.Text
                };
                Odgovor o = Komunikacija.Instance.VratiFilmovePoNazivu(film);
                if (!o.Uspesno)
                {
                    MessageBox.Show("Sistem ne moze da vrati filmove po nazivu\n" + o.Greska);
                }
                lista = (List<Film>)o.Rezultat;              
            }
            catch (Exception e)
            {
                MessageBox.Show("Sistem ne moze da vrati filmove po nazivu\n" + e.Message);
            }

            if(lista != null && lista.Count == 0)
            {
                MessageBox.Show("Sistem ne moze da vrati filmove po zadatoj verdnosti");
            }
            else
            {
                MessageBox.Show("Sistem je vratio filmove po zadatoj verdnosti");
            }

            return lista;
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
            }catch(Exception e)
            {
                MessageBox.Show("Sistem ne moze da vrati filmove\n" + e.Message);
            }
            return lista;
        }
    }
}
