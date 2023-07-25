using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.FilmSO
{
    public class VratiFilmovePoNazivuSO : SistemskaOperacijaBaza
    {
        public List<Film> Rezultat { get; set; }

        public VratiFilmovePoNazivuSO(Film film)
        {
            this.film = film;
        }

        private Film film;
        protected override void Izvrsi()
        {
            film.Uslov = $"f.Naziv like '{film.Naziv}%'";
            Rezultat = repozitorijum.VratiPoUslovu(film).OfType<Film>().ToList();
        }
    }
}
