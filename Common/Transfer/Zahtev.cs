using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Transfer
{
    [Serializable]
    public class Zahtev
    {
        public object Objekat { get; set; }

        public Operacije Operacija { get; set; }
    }
}
