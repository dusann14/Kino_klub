using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.RacunSO
{
    public class ZapamtiRacunSO : SistemskaOperacijaBaza
    {
        private Racun racun;

        public ZapamtiRacunSO(Racun racun)
        {
            this.racun = racun;
        }

        protected override void Izvrsi()
        {
            repozitorijum.Dodaj(racun);
        }
    }
}
