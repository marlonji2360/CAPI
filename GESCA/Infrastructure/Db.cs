using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace GESCA.Infrastructure
{
    public static class Db
    {
        public static SqlConnection Create()
        {
            var cs = ConfigurationManager.ConnectionStrings["DbCapacitaciones"]?.ConnectionString;
            return new SqlConnection(cs);
        }
    }
}
