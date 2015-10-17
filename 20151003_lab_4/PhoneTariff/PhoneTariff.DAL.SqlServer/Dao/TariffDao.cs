using PhoneTariff.DAL.Common.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneTariff.DAL.Common.Domain;
using PhoneTariff.DAL.Common;
using System.Data.Common;
using System.Data;

namespace PhoneTariff.DAL.SqlServer.Dao
{
    public class TariffDao : Common.Dao.ITariffDao
    {
        private IDatabase database;
        private const string SQL_FIND_ALL = "SELECT * FROM TARIFF";
        private const string SQL_FIND_BY_ID = "SELECT * FROM TARIFF WHERE Id=@Id";
        private const string SQL_UPDATE = "UPDATE Tariff SET Name=@Name, BasicFee=@BasicFee WHERE Id=@Id";

        public TariffDao(IDatabase database)
        {
            this.database = database;
        }

        public IList<Tariff> findAll()
        {
            using(var reader = database.ExecuteReader(CreateFindallCommand()))
            {
                var tariffs = new List<Tariff>();
                while (reader.Read())
                {
                    tariffs.Add(new Tariff(
                       (string)reader["id"],
                       (string)reader["name"],
                        (double)reader["BasicFee"]));
                }

                return tariffs;
            }
        }

        public Tariff FindById(string tariffId)
        {
            using(var reader = database.ExecuteReader(CreateFindByIdCommand(tariffId)))
            {
                if (reader.Read())
                {
                    return new Tariff(
                       (string)reader["id"],
                       (string)reader["name"],
                        (double)reader["BasicFee"]);
                }
                return null;
            }
        }

        public bool Update(Tariff tariff)
        {
            DbCommand updateCommand = database.CreateCommand(SQL_UPDATE);
            database.DefineParameter(updateCommand, "@Id", DbType.String, tariff.Id);
            database.DefineParameter(updateCommand, "@Name", DbType.String, tariff.Name);
            database.DefineParameter(updateCommand, "@BasicFee", DbType.Double, tariff.BasicFee);

            return database.ExecuteNonQuery(updateCommand) == 1;
        }


        #region Private
        private DbCommand CreateFindallCommand()
        {
            return database.CreateCommand(SQL_FIND_ALL);
        }

        private DbCommand CreateFindByIdCommand(string id)
        {
            DbCommand cmd = database.CreateCommand(SQL_FIND_BY_ID);
            database.DefineParameter(cmd, "@Id", System.Data.DbType.String, id);
            return cmd;
        }
        #endregion
    }
}
