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
    public class Film : IEntitet
    {
        [Browsable(false)]
        public int Id { get; set; }

        public string Naziv { get; set; }

        public string DuzinaTrajanja { get; set; }

        public double CenaPoDanu { get; set; }

        public DateTime Datum { get; set; }

        public Reditelj Reditelj { get; set; }

        public double ProsecnaOcena { get; set; }

        public List<Zanr> Zanrovi { get; set; }

        [Browsable(false)]
        public string Uslov { get; set; }

        [Browsable(false)]
        public string ImeTabele => "Film";
        [Browsable(false)]
        public string UbaciVrednosti => $"'{Naziv}', '{DuzinaTrajanja}', {CenaPoDanu}, '{Datum}', {Reditelj.Id}";
        [Browsable(false)]
        public string IdName => "Id";
        [Browsable(false)]
        public string JoinUslov => "join Reditelj r on (r.Id = f.Reditelj)";
        [Browsable(false)]
        public string Alias => "f";
        [Browsable(false)]
        public string Select => "*";
        [Browsable(false)]
        public string WhereUslov => $"{Uslov}";
        [Browsable(false)]
        public string UpdateVrednosti => "";

        public IEntitet VratiJednog(SqlDataReader reader)
        {
            return new Film
            {
                Id = (int)reader[0],
                Naziv = (string)reader[1],
                DuzinaTrajanja = (string)reader[2],
                CenaPoDanu = (float)reader[3],
                Datum = (DateTime)reader[4],
                Reditelj = new Reditelj
                {
                    Id = (int)reader[6],
                    ImePrezime = (string)reader[7],
                }
            };
        }

        public List<IEntitet> VratiVise(SqlDataReader reader)
        {
            List<IEntitet> entiteti = new List<IEntitet>();

            while (reader.Read())
            {               
                entiteti.Add(new Film
                {
                    Id = (int)reader[0],
                    Naziv = (string)reader[1],
                    DuzinaTrajanja = (string)reader[2],
                    CenaPoDanu = (double)reader[3],
                    Datum = (DateTime)reader[4],
                    Reditelj = new Reditelj
                    {
                        Id = (int)reader[6],
                        ImePrezime = (string)reader[7],
                    }
                });
            }
            return entiteti;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Film))
                return false;

            Film film = (Film)obj;

            if (this.Id != film.Id)
                return false;

            return true;
        }
    }
}
