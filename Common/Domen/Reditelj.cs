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
    public class Reditelj : IEntitet
    {
        public int Id { get; set; }

        public string ImePrezime { get; set; }

        public override string ToString()
        {
            return $"{ImePrezime}";
        }

        [Browsable(false)]
        public string Uslov { get; set; }

        [Browsable(false)]
        public string ImeTabele => "Reditelj";
        [Browsable(false)]
        public string UbaciVrednosti => "";
        [Browsable(false)]
        public string IdName => "Id";
        [Browsable(false)]
        public string JoinUslov => "";
        [Browsable(false)]
        public string Alias => "";
        [Browsable(false)]
        public string Select => "*";
        [Browsable(false)]
        public string WhereUslov => $"{Uslov}";
        [Browsable(false)]
        public string UpdateVrednosti => ""; 

        public IEntitet VratiJednog(SqlDataReader reader)
        {
            return new Reditelj
            {
                Id = (int)reader[0],
                ImePrezime = (string)reader[1]
            };
        }

        public List<IEntitet> VratiVise(SqlDataReader reader)
        {
            List<IEntitet> entiteti = new List<IEntitet>();

            while (reader.Read())
            {
                entiteti.Add(new Reditelj
                {
                    Id = (int)reader[0],
                    ImePrezime = (string)reader[1]
                });
            }
            return entiteti;
        }
    }
}
