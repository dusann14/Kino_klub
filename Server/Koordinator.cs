using Server.KontrolerForme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public class Koordinator
    {
        public Server ServerForma { get; set; }

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
            kontrolerForme = new KontrolerForme.KontrolerForme();
        }

        private KontrolerForme.KontrolerForme kontrolerForme;

        internal void OtvoriServerFormu()
        {
            ServerForma = kontrolerForme.NapraviServerFormu();
            ServerForma.ShowDialog();
        }
    }
}
