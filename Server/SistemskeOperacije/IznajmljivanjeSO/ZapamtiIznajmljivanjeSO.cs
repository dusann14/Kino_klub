using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.IznajmljivanjeSO
{
    public class ZapamtiIznajmljivanjeSO : SistemskaOperacijaBaza
    {
        private Iznajmljivanje iznajmljivanje;

        public ZapamtiIznajmljivanjeSO(Iznajmljivanje iznajmljivanje)
        {
            this.iznajmljivanje = iznajmljivanje;
        }

        protected override void Izvrsi()
        {
            iznajmljivanje.Id = repozitorijum.Dodaj(iznajmljivanje);

            foreach(Film film in iznajmljivanje.Filmovi)
            {
                repozitorijum.Dodaj(new Stavka
                {
                    Iznajmljivanje = iznajmljivanje,
                    Film = film
                });
            }

        }
    }
}
