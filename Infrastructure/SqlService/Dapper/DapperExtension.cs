﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SqlServices.Dapper
{
    public static class DapperExtension
    {
        public static IEnumerable<dynamic> Query(this SqlConnection sqlConnection, string query)
        {
            return sqlConnection.Query<dynamic>(query).ToList();
        }

        public static dynamic ExecuteQuery(this SqlConnection sqlConnection, string query)
        {
            return sqlConnection.Query<dynamic>(query).FirstOrDefault();
        }
    }
}
