using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.RediteljSO
{
    public class VratiRediteljeSO : SistemskaOperacijaBaza
    {
        public List<Reditelj> Rezultat { get; set; }
        protected override void Izvrsi()
        {
            Rezultat = repozitorijum.VratiSve(new Reditelj()).OfType<Reditelj>().ToList();
        }
    }
}
