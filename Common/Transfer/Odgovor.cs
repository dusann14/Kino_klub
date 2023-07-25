using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Transfer
{
    [Serializable]
    public class Odgovor
    {
        public bool Uspesno { get; set; }
        public string Greska { get; set; }
        public object Rezultat { get; set; }
    }
}
