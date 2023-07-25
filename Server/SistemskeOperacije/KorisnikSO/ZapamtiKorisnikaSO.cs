using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.KorisnikSO
{
    public class ZapamtiKorisnikaSO : SistemskaOperacijaBaza
    {
        private Korisnik korisnik;

        public ZapamtiKorisnikaSO(Korisnik korisnik)
        {
            this.korisnik = korisnik;
        }

        protected override void Izvrsi()
        {
            repozitorijum.Dodaj(korisnik);
        }
    }
}
