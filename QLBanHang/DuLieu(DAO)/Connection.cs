using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuLieu_DAO_
{
    public class Connection
    {
        public SqlConnection Connect()
        {
            string cnstr = "Data Source=HUYNHNHU\\HNHU_1;Initial Catalog=QLBH;Integrated Security=True";

            //string cnstr = "Data Source=LAPTOP-8VUUID4Q;Initial Catalog=QLBH;Integrated Security=True";
            SqlConnection conn = new SqlConnection(cnstr);
            return conn;
        }    
    }
}
