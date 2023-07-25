using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.PrijavaSO
{
    public class PrijavaSO : SistemskaOperacijaBaza
    {
        public Korisnik Rezultat { get; set; }

        public PrijavaSO(Korisnik korisnik)
        {
            this.korisnik = korisnik;
        }

        private Korisnik korisnik;
        protected override void Izvrsi()
        {
            korisnik.Uslov = $"k.KorisnickoIme = '{korisnik.KorisnickoIme}' and k.Lozinka = '{korisnik.Lozinka}' and k.Uloga = {korisnik.Uloga.Id}";
            Rezultat = (Korisnik)repozitorijum.VratiJednog(korisnik);
        }
    }
}
