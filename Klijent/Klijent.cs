using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent
{
    public partial class Klijent : Form
    {
        public Klijent()
        {
            InitializeComponent();
        }

        internal void PostaviPanel(UserControl userControl)
        {
            panel1.Controls.Clear();
            userControl.Parent = panel1;
            userControl.Dock = DockStyle.Fill;
        }
    }
}
