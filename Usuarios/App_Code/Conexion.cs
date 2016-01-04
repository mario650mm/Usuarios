using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Usuarios
{
    public class Conexion
    {
        public SqlConnection conn = null;
        public Conexion()
        {
            conn = new SqlConnection(@"Data Source=DEVMARIO\SQLEXPRESS;Initial Catalog=users;Integrated Security=True;Pooling=False");
        }

       /* public void conectar()
        {
            if (conn == null)
            {
                conn.Open();
            }
        }

        public void desconectar()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }*/
    }
}