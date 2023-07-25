using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.IznajmljivanjeSO
{
    internal class VratiIznajmljivanjaPoImenuKorisnikaSO : SistemskaOperacijaBaza
    {
        public List<Iznajmljivanje> Rezultat { get; set; }

        public VratiIznajmljivanjaPoImenuKorisnikaSO(Iznajmljivanje iznajmljivanje)
        {
            this.iznajmljivanje = iznajmljivanje;
        }

        private Iznajmljivanje iznajmljivanje;
        protected override void Izvrsi()
        {
            iznajmljivanje.Uslov = $"k.ImePrezime like '{iznajmljivanje.Korisnik.ImePrezime}'";
            Rezultat = repozitorijum.VratiSve(new Iznajmljivanje()).OfType<Iznajmljivanje>().ToList();
        }
    }
}
