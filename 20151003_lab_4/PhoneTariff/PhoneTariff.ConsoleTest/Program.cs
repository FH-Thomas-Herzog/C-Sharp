using PhoneTariff.DAL.Common;
using PhoneTariff.DAL.SqlServer;
using PhoneTariff.DAL.SqlServer.Dao;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneTariff.DAL.Common.Dao;

namespace PhoneTariff.ConsoleTest
{
    class Program
    {
        private static string conString = ConfigurationManager.ConnectionStrings["PhoneTariffDB"].ConnectionString;

        public static void Main(string[] args)
        {
            IDatabase database = new Database(conString);

            ITariffDao dao = new TariffDao(database);

            Console.Out.WriteLine(dao.FindById("A1").Name);

            Console.Read();
        }
    }
}
