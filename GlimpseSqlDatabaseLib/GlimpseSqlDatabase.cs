using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Glimpse.EnterpriseLibrary.Data
{
    public class GlimpseSqlDatabase : SqlDatabase
    {
        private static readonly FieldInfo dbProviderFactoryField =
            typeof(Database).GetField("dbProviderFactory", BindingFlags.Instance | BindingFlags.NonPublic);

        public GlimpseSqlDatabase(string connectionString)
            : base(connectionString)
        {
            dbProviderFactoryField.SetValue(this, DbProviderFactories.GetFactory("System.Data.SqlClient"));
        }
    }
}
