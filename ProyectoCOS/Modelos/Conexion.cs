using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProyectoCOS.Modelos
{
    public class Conexion
    {
        private SqlConnection conn;
        public Conexion()
        {
            this.conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source=ROMULO-PC;" +
            "Initial Catalog=cos;" +
            "User id=sa;" +
            "Password=123456;";
            conn.Open();
        }

        public SqlConnection Conn { get => conn; set => conn = value; }
    }
}
