﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneTariff.DAL.Common
{
    public interface IDatabase
    {
        IDataReader ExecuteReader(DbCommand cmd);

        int ExecuteNonQuery(DbCommand cmd);
        DbCommand CreateCommand(string genericCommandText);
        int DeclareParameter(DbCommand command, string name, DbType type);
        void DefineParameter(DbCommand command, string name, DbType type, object value);
        void SetParameter(DbCommand command, string name, object value);
    }
}   
