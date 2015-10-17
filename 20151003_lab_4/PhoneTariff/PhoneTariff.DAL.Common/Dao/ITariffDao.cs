using PhoneTariff.DAL.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneTariff.DAL.Common.Dao
{
    public interface ITariffDao
    {
        Tariff FindById(string tariffId);

        IList<Tariff> findAll();

        bool Update(Tariff tariff);
    }
}
