using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domen
{
    public interface IEntitet
    {
        string ImeTabele { get; }
        string UbaciVrednosti { get; }
        string IdName { get; }
        string JoinUslov { get; }
        string Alias { get; }
        string Select { get; }
        string WhereUslov { get; }

        string UpdateVrednosti { get; }

        List<IEntitet> VratiVise(SqlDataReader reader);

        IEntitet VratiJednog(SqlDataReader reader);
    }
}
