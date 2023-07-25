using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.FilmSO
{
    public class VratiFilmoveSO : SistemskaOperacijaBaza
    {
        public List<Film> Rezultat { get; set; }
        protected override void Izvrsi()
        {
            Rezultat = repozitorijum.VratiSve(new Film()).OfType<Film>().ToList();
        }
    }
}
