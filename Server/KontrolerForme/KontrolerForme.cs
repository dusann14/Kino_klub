using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.KontrolerForme
{
    public class KontrolerForme
    {
        public Server Forma { get; set; }

        public ServerKlasa Server { get; set; }
        public Server NapraviServerFormu()
        {
            Forma = new Server();
            Forma.StartPosition = FormStartPosition.CenterScreen;
            Forma.button1.Enabled = true;
            Forma.button2.Enabled = false;
            Forma.Load += Forma_Load;
            Forma.button1.Click += Button1_Click;
            Forma.button2.Click += Button2_Click;
            return Forma;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                Forma.button1.Enabled = true;
                Forma.button2.Enabled = false;
                Server.Stop();
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Server = new ServerKlasa();
                Forma.button1.Enabled = false;
                Forma.button2.Enabled = true;
                Thread thread = new Thread(Server.Osluskuj);
                thread.IsBackground = true;
                thread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Forma_Load(object sender, EventArgs e)
        {
            Thread nitVreme = new Thread(PostaviVreme);
            nitVreme.IsBackground = true;
            nitVreme.Start();
        }

        public void PostaviVreme()
        {
            while (true)
            {
                Forma.Invoke(new Action(() =>
                {
                    Forma.label1.Text = DateTime.Now.ToLongTimeString();
                }
                ));
                Thread.Sleep(1000);
            }
        }
    }
}
