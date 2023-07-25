using Common.Domen;
using Server.DBConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repozitorijum.RepozitorijumImpl
{
    internal class GenerickiRepo : IDBRepozitorijum<IEntitet>
    {
        public void Close()
        {
            DBConnectionFactory.Instance.GetDbConnection().Close();
        }

        public void Commit()
        {
            DBConnectionFactory.Instance.GetDbConnection().Commit();
        }

        public void Rollback()
        {
            DBConnectionFactory.Instance.GetDbConnection().Rollback();
        }

        public int Dodaj(IEntitet entitet)
        {
            SqlCommand command = DBConnectionFactory.Instance.GetDbConnection().CreateCommand($"insert into {entitet.ImeTabele} output inserted.{entitet.IdName} values ({entitet.UbaciVrednosti})");
            int newID = (int)command.ExecuteScalar();
            if (newID == null)
            {
                throw new Exception("Greska u bazi!");
            }
            return newID;
        }

        public void Obrisi(IEntitet entitet)
        {
            SqlCommand command = DBConnectionFactory.Instance.GetDbConnection().CreateCommand($"delete from {entitet.ImeTabele} where {entitet.WhereUslov}");
            command.ExecuteNonQuery();
        }

        public void Promeni(IEntitet entitet)
        {
            SqlCommand command = DBConnectionFactory.Instance.GetDbConnection().CreateCommand($"update {entitet.ImeTabele} set {entitet.UpdateVrednosti} where {entitet.WhereUslov}");
            if (command.ExecuteNonQuery() != 1)
            {
                throw new Exception("Greska u bazi!");
            }
        }

        public List<IEntitet> VratiPoUslovu(IEntitet entitet)
        {
            List<IEntitet> entiteti = null;
            SqlCommand command = DBConnectionFactory.Instance.GetDbConnection().CreateCommand($"select {entitet.Select} from {entitet.ImeTabele} {entitet.Alias} {entitet.JoinUslov} where {entitet.WhereUslov};");
            SqlDataReader reader = command.ExecuteReader();
            entiteti = entitet.VratiVise(reader);
            reader.Close();
            return entiteti;
        }

        public IEntitet VratiJednog(IEntitet entitet)
        {
            IEntitet pronadjeni = null;
            SqlCommand command = DBConnectionFactory.Instance.GetDbConnection().CreateCommand($"select {entitet.Select} from {entitet.ImeTabele} {entitet.Alias} {entitet.JoinUslov} where {entitet.WhereUslov};");
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                pronadjeni = entitet.VratiJednog(reader);
            }
            reader.Close();
            return pronadjeni;
        }

        public List<IEntitet> VratiSve(IEntitet entitet)
        {
            List<IEntitet> entiteti = null;
            SqlCommand command = DBConnectionFactory.Instance.GetDbConnection().CreateCommand($"select {entitet.Select} from {entitet.ImeTabele} {entitet.Alias} {entitet.JoinUslov};");
            SqlDataReader reader = command.ExecuteReader();
            entiteti = entitet.VratiVise(reader);
            reader.Close();
            return entiteti;
        }

    }
}
