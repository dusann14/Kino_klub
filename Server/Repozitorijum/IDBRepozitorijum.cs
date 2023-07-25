using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repozitorijum
{
    public interface IDBRepozitorijum<T> : IGenerickiRepo<T> where T : class
    {
        void Commit();
        void Rollback();
        void Close();
    }
}
