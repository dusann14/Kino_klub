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
    public class Racun : IEntitet
    {
        public int Id { get; set; }
        public Iznajmljivanje Iznajmljivanje { get; set; }

        public double UkupnaCena { get; set; }

        public DateTime DatumKreiranja { get; set; }

        [Browsable(false)]
        public string Uslov { get; set; }

        [Browsable(false)]
        public string ImeTabele => "Racun";
        [Browsable(false)]
        public string UbaciVrednosti => $"{Iznajmljivanje.Id}, {UkupnaCena}, '{DatumKreiranja}'";
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
            throw new NotImplementedException();
        }

        public List<IEntitet> VratiVise(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
