using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.FilmSO
{
    public class ZapamtiFilmSO : SistemskaOperacijaBaza
    {
        private Film film;

        public ZapamtiFilmSO(Film film)
        {
            this.film = film;
        }   

        protected override void Izvrsi()
        {
            film.Id = repozitorijum.Dodaj(film);

            foreach(Zanr z in film.Zanrovi)
            {
                FilmZanr filmZanr = new FilmZanr
                {
                    Film = film,
                    Zanr = z
                };
                repozitorijum.Dodaj(filmZanr);
            }
        }
    }
}
