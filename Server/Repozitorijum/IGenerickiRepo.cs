using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repozitorijum
{
    public interface IGenerickiRepo<T> where T : class
    {
        void Promeni(T entitet);
        void Obrisi(T entitet);
        int Dodaj(T entitet);
        List<T> VratiSve(T entitet);

        List<T> VratiPoUslovu(T entitet);
        IEntitet VratiJednog(T entitet);
    }
}
