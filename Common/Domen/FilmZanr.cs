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
    public class FilmZanr : IEntitet
    {
        public int Id { get; set; }

        public Film Film { get; set; }

        public Zanr Zanr { get; set; }


        [Browsable(false)]
        public string Uslov { get; set; }

        [Browsable(false)]
        public string ImeTabele => "FilmZanr";
        [Browsable(false)]
        public string UbaciVrednosti => $"{Film.Id}, {Zanr.Id}";
        [Browsable(false)]
        public string IdName => "Id";
        [Browsable(false)]
        public string JoinUslov => "join Film f on (fz.Film = f.Id) join Zanr z on (fz.Zanr = z.Id)";
        [Browsable(false)]
        public string Alias => "fz";
        [Browsable(false)]
        public string Select => "*";
        [Browsable(false)]
        public string WhereUslov => $"{Uslov}";
        [Browsable(false)]
        public string UpdateVrednosti => "";

        public IEntitet VratiJednog(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public List<IEntitet> VratiVise(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
