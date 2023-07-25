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
    public class Iznajmljivanje : IEntitet
    {
        [Browsable(false)]
        public int Id { get; set; }

        public Korisnik Korisnik { get; set; }

        public DateTime DatumIznajmljivanja { get; set; }

        public DateTime DatumTrajanja { get; set; }

        public int Dani { get; set; }

        public double Cena { get; set; }

        public List<Film> Filmovi { get; set; }

        [Browsable(false)]
        public string Uslov { get; set; }

        [Browsable(false)]
        public string ImeTabele => "Iznajmljivanje";
        [Browsable(false)]
        public string UbaciVrednosti => $"'{Korisnik.Id}', '{DatumIznajmljivanja}', '{DatumTrajanja}', {Dani}, {Cena}";
        [Browsable(false)]
        public string IdName => "Id";
        [Browsable(false)]
        public string JoinUslov => "join Korisnik k on (k.Id = i.Korisnik) join Uloga u on (u.Id = k.Uloga)";
        [Browsable(false)]
        public string Alias => "i";
        [Browsable(false)]
        public string Select => "*";
        [Browsable(false)]
        public string WhereUslov => $"{Uslov}";
        [Browsable(false)]
        public string UpdateVrednosti => "";

        public IEntitet VratiJednog(SqlDataReader reader)
        {
            return new Iznajmljivanje
            {
                Id = (int)reader[0],
                DatumIznajmljivanja = (DateTime)reader[2],
                DatumTrajanja = (DateTime)reader[3],
                Dani = (int)reader[4],
                Cena = (double)reader[5],
                Korisnik = new Korisnik
                {
                    Id = (int)reader[6],
                    ImePrezime = (string)reader[7],
                    DatumRodjenja = (DateTime)reader[8],
                    KorisnickoIme = (string)reader[9],
                    Lozinka = (string)reader[10],
                    Uloga = new Uloga
                    {
                        Id = (int)reader[12],
                        Naziv = (string)reader[13]
                    }
                }
            };
        }

        public List<IEntitet> VratiVise(SqlDataReader reader)
        {
            List<IEntitet> entiteti = new List<IEntitet>();

            while (reader.Read())
            {
                entiteti.Add(new Iznajmljivanje
                {
                    Id = (int)reader[0],
                    DatumIznajmljivanja = (DateTime)reader[2],
                    DatumTrajanja = (DateTime)reader[3],
                    Dani = (int)reader[4],
                    Cena = (double)reader[5],
                    Korisnik = new Korisnik
                    {
                        Id = (int)reader[6],
                        ImePrezime = (string)reader[7],
                        DatumRodjenja = (DateTime)reader[8],
                        KorisnickoIme = (string)reader[9],
                        Lozinka = (string)reader[10],
                        Uloga = new Uloga
                        {
                            Id = (int)reader[12],
                            Naziv = (string)reader[13]
                        }
                    }
                });
            }
            return entiteti;
        }
    }
}
