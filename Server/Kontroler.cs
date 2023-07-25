using Common.Domen;
using Server.SistemskeOperacije;
using Server.SistemskeOperacije.FilmSO;
using Server.SistemskeOperacije.IznajmljivanjeSO;
using Server.SistemskeOperacije.KorisnikSO;
using Server.SistemskeOperacije.OcenaSO;
using Server.SistemskeOperacije.PrijavaSO;
using Server.SistemskeOperacije.RacunSO;
using Server.SistemskeOperacije.RediteljSO;
using Server.SistemskeOperacije.ZanrSO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Kontroler
    {
        private static Kontroler instance;

        public static Kontroler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Kontroler();
                }
                return instance;
            }
        }

        private Kontroler() { }

        internal Korisnik Prijava(Korisnik korisnik)
        {
            PrijavaSO so = new PrijavaSO(korisnik);
            so.Template();
            return so.Rezultat;
        }

        internal List<Uloga> VratiUloge()
        {
            VratiUlogeSO so = new VratiUlogeSO();
            so.Template();
            return so.Rezultat;
        }

        internal List<Zanr> VratiZanrove()
        {
            VratiZanroveSO so = new VratiZanroveSO();
            so.Template();
            return so.Rezultat;
        }

        internal List<Reditelj> VratiReditelje()
        {
            VratiRediteljeSO so = new VratiRediteljeSO();
            so.Template();
            return so.Rezultat;
        }

        internal void ZapamtiFilm(Film film)
        {
            ZapamtiFilmSO so = new ZapamtiFilmSO(film);
            so.Template();
        }

        internal object VratiFilmove()
        {
            VratiFilmoveSO so = new VratiFilmoveSO();
            so.Template();
            return so.Rezultat;
        }

        internal List<Film> VratiFilmovePoNazivu(Film film)
        {
            VratiFilmovePoNazivuSO so = new VratiFilmovePoNazivuSO(film);
            so.Template();
            return so.Rezultat;
        }

        internal void ZapamtiIznajmljivanje(Iznajmljivanje iznajmljivanje)
        {
            ZapamtiIznajmljivanjeSO so = new ZapamtiIznajmljivanjeSO(iznajmljivanje);
            so.Template();
        }

        internal List<Iznajmljivanje> VratiIznajmlijvanja()
        {
            VratiIznajmljivanjaSO so = new VratiIznajmljivanjaSO();
            so.Template();
            return so.Rezultat;
        }

        internal List<Iznajmljivanje> VratiIznajmlijvanjaPoImenuKorisnika(Iznajmljivanje iznajmljivanje)
        {
            VratiIznajmljivanjaPoImenuKorisnikaSO so = new VratiIznajmljivanjaPoImenuKorisnikaSO(iznajmljivanje);
            so.Template();
            return so.Rezultat;
        }

        internal void ZapamtiRacun(Racun racun)
        {
            ZapamtiRacunSO so = new ZapamtiRacunSO(racun);
            so.Template();
        }

        internal object VratiOcene()
        {
            VratiOceneSO so = new VratiOceneSO();
            so.Template();
            return so.Rezultat;
        }

        internal void OceniFilm(Ocena ocena)
        {
            OceniFilmSO so = new OceniFilmSO(ocena);
            so.Template();
        }

        internal void ZapamtiKorisnika(Korisnik korisnik)
        {
            ZapamtiKorisnikaSO so = new ZapamtiKorisnikaSO(korisnik);
            so.Template();
        }
    }
}
