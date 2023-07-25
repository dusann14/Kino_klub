using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.ZanrSO
{
    public class VratiZanroveSO : SistemskaOperacijaBaza
    {
        public List<Zanr> Rezultat { get; set; }
        protected override void Izvrsi()
        {
            Rezultat = repozitorijum.VratiSve(new Zanr()).OfType<Zanr>().ToList();
        }
    }
}
