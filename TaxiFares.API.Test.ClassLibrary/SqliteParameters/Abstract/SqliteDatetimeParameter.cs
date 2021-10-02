using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiFares.API.Test.ClassLibrary.SqliteParameters.Abstract
{
    public class SqliteDatetimeParameter : SqliteParameter
    {
        public SqliteDatetimeParameter(string paramName, 
            DateTime dateTime) : base(paramName, 
                dateTime.ToString(Sql.DateFormat))
        {
        }
    }
}
