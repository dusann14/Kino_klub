using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domen
{
    [Serializable]
    public class Ocena : IEntitet
    {
        public int Id { get; set; }

        public Film Film { get; set; }

        public Korisnik Korisnik { get; set; }

        public int OcenaBroj { get; set; }

        [Browsable(false)]
        public string Uslov { get; set; }

        [Browsable(false)]
        public string ImeTabele => "Ocena";
        [Browsable(false)]
        public string UbaciVrednosti => $"{Film.Id}, {Korisnik.Id}, {OcenaBroj}";
        [Browsable(false)]
        public string IdName => "Id";
        [Browsable(false)]
        public string JoinUslov => "join Film f on (f.Id = o.Film) join Korisnik k on (k.Id = o.Korisnik)";
        [Browsable(false)]
        public string Alias => "o";
        [Browsable(false)]
        public string Select => "*";
        [Browsable(false)]
        public string WhereUslov => $"{Uslov}";
        [Browsable(false)]
        public string UpdateVrednosti => "";

        public IEntitet VratiJednog(SqlDataReader reader)
        {
            return new Ocena
            {
                Id = (int)reader[0],
                OcenaBroj = (int)reader[3],
                Film = new Film
                {
                    Id = (int)reader[4],
                    Naziv = (string)reader[5],
                    DuzinaTrajanja = (string)reader[6],
                    CenaPoDanu = (float)reader[7],
                    Datum = (DateTime)reader[8],
                },
                Korisnik = new Korisnik
                {
                    Id = (int)reader[10],
                    ImePrezime = (string)reader[11],
                    DatumRodjenja = (DateTime)reader[12],
                    KorisnickoIme = (string)reader[13],
                    Lozinka = (string)reader[14],
                }
            };
        }

        public List<IEntitet> VratiVise(SqlDataReader reader)
        {
            List<IEntitet> entiteti = new List<IEntitet>();

            while (reader.Read())
            {
                entiteti.Add(new Ocena
                {
                    Id = (int)reader[0],
                    OcenaBroj = (int)reader[3],
                    Film = new Film
                    {
                        Id = (int)reader[4],
                        Naziv = (string)reader[5],
                        DuzinaTrajanja = (string)reader[6],
                        CenaPoDanu = (double)reader[7],
                        Datum = (DateTime)reader[8],                        
                    },
                    Korisnik = new Korisnik
                    {
                        Id = (int)reader[10],
                        ImePrezime = (string)reader[11],
                        DatumRodjenja = (DateTime)reader[12],
                        KorisnickoIme = (string)reader[13],
                        Lozinka = (string)reader[14],
                    }
                });
            }
            return entiteti;
        }
    }
}
