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
        public SqlConnection con = null;
        public Conexion()
        {
            con = new SqlConnection(@"Data Source=DEVMARIO\SQLEXPRESS;Initial Catalog=users;Integrated Security=True;Pooling=False");
        }

        public void conectar()
        {
            if(con == null){
                con.Open();
            }
        }

        public void desconectar()
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }
}