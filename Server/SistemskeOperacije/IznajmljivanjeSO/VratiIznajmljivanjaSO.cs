using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.IznajmljivanjeSO
{
    public class VratiIznajmljivanjaSO : SistemskaOperacijaBaza
    {
        public List<Iznajmljivanje> Rezultat { get; set; }
        protected override void Izvrsi()
        {
            Rezultat = repozitorijum.VratiSve(new Iznajmljivanje()).OfType<Iznajmljivanje>().ToList();
        }
    }
}
