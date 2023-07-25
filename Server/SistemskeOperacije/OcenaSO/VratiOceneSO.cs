using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.OcenaSO
{
    public class VratiOceneSO : SistemskaOperacijaBaza
    {
        public List<Ocena> Rezultat { get; set; }
        protected override void Izvrsi()
        {
            Rezultat = repozitorijum.VratiSve(new Ocena()).OfType<Ocena>().ToList();
        }
    }
}
