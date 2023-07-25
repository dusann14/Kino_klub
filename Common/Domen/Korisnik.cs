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
    public class Korisnik : IEntitet
    {
        public int Id { get; set; }

        public string ImePrezime { get; set; }

        public string KorisnickoIme { get; set; }

        public string Lozinka { get; set; }

        public DateTime DatumRodjenja { get; set; }

        public override string ToString()
        {
            return $"{ImePrezime}";
        }
        public Uloga Uloga { get; set; }

        [Browsable(false)]
        public string Uslov { get; set; }

        [Browsable(false)]
        public string ImeTabele => "Korisnik";
        [Browsable(false)]
        public string UbaciVrednosti => $"'{ImePrezime}', '{DatumRodjenja}', '{KorisnickoIme}', '{Lozinka}', {Uloga.Id}";
        [Browsable(false)]
        public string IdName => "Id";
        [Browsable(false)]
        public string JoinUslov => "join Uloga u on (u.Id = k.Uloga)";
        [Browsable(false)]
        public string Alias => "k";
        [Browsable(false)]
        public string Select => "*";
        [Browsable(false)]
        public string WhereUslov => $"{Uslov}";
        [Browsable(false)]
        public string UpdateVrednosti => "";

        public IEntitet VratiJednog(SqlDataReader reader)
        {
            return new Korisnik
            {
                Id = (int)reader[0],
                ImePrezime = (string)reader[1],
                DatumRodjenja = (DateTime)reader[2],
                KorisnickoIme = (string)reader[3],
                Lozinka = (string)reader[4],
                Uloga = new Uloga
                {
                    Id = (int)reader[6],
                    Naziv = (string)reader[7]
                }
            };
        }

        public List<IEntitet> VratiVise(SqlDataReader reader)
        {
            List<IEntitet> entiteti = new List<IEntitet>();

            while (reader.Read())
            {
                entiteti.Add(new Korisnik
                {
                    Id = (int)reader[0],
                    ImePrezime = (string)reader[1],
                    DatumRodjenja = (DateTime)reader[2],
                    KorisnickoIme = (string)reader[3],
                    Lozinka = (string)reader[4],
                    Uloga = new Uloga
                    {
                        Id = (int)reader[6],
                        Naziv = (string)reader[7]
                    }
                });
            }
            return entiteti;
        }
    }
}
