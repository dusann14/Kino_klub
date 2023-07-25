using Common.Domen;
using Server.Repozitorijum;
using Server.Repozitorijum.RepozitorijumImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    public abstract class SistemskaOperacijaBaza
    {
        protected IDBRepozitorijum<IEntitet> repozitorijum;

        public SistemskaOperacijaBaza()
        {
            repozitorijum = new GenerickiRepo();
        }
        public void Template()
        {
            try
            {
                Izvrsi();
                repozitorijum.Commit();
            }
            catch (Exception)
            {
                repozitorijum.Rollback();
                throw;
            }
            finally
            {
                repozitorijum.Close();
            }
        }

        protected abstract void Izvrsi();
    }
}
