using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.OcenaSO
{
    public class OceniFilmSO : SistemskaOperacijaBaza
    {
        private Ocena ocena;

        public OceniFilmSO(Ocena ocena)
        {
            this.ocena = ocena;
        }

        protected override void Izvrsi()
        {
            repozitorijum.Dodaj(ocena);
        }
    }
}
