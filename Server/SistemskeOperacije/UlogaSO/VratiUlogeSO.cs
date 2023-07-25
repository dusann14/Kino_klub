using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    public class VratiUlogeSO : SistemskaOperacijaBaza
    {
        public List<Uloga> Rezultat { get; set; }
        protected override void Izvrsi()
        {
            Rezultat = repozitorijum.VratiSve(new Uloga()).OfType<Uloga>().ToList();
        }
    }
}
