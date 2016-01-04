using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Diagnostics;


namespace Usuarios
{
   
    public partial class index :  System.Web.UI.Page
    {
        Conexion con = new Conexion();
        //SqlConnection con = new SqlConnection(@"Data Source=DEVMARIO\SQLEXPRESS;Initial Catalog=users;Integrated Security=True;Pooling=False");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                display();
            }
        }

        protected void btnnew_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                lblMsg.Text = "";
                val1.Enabled = true;
                val2.Enabled = true;
                if (txtNombre.Text !=null && txtApellidos !=null)
                {
                    val1.Enabled = false;
                    val2.Enabled = false;
                    con.conn.Open();
                    string sql = "insert into partner(name,lastName,street,noExt,noInt,phone,movil,cp,state,city) values('" + txtNombre.Text + "','" + txtApellidos.Text + "','" + txtCalle.Text + "','" + txtNoExt.Text + "','" + txtNoInt.Text + "','" + txtTelefono.Text + "','" + txtMovil.Text + "','" + txtCP.Text + "','" + txtEstado.Text + "','" + txtCiudad.Text + "')";
                    SqlCommand cmd = new SqlCommand(sql, con.conn);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertScript", "alert('Registro Éxitoso')", true);
                    clear();
                }
                else
                {
                    lblMsg.Text = "Campos Vacíos";
                }    
            }
            catch(System.FormatException){
                lblMsg.Text = "Revise el formato de los campos";
            }
            catch (System.Web.HttpException)
            {
                lblMsg.Text = "Error al registrar";
            }
            finally
            {
                con.conn.Close();
                display();
            }

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                lblMsg.Text = "";
                val1.Enabled = true;
                val2.Enabled = true;
                con.conn.Open();
                string sql = "update partner set name='" + txtNombre.Text + "',lastName='" + txtApellidos.Text + "', street='" + txtCalle.Text + "', noExt='" + txtNoExt.Text + "', noInt='" + txtNoInt.Text + "', phone='" + txtTelefono.Text + "', movil='" + txtMovil.Text + "', cp='" + txtCP.Text + "', state='" + txtEstado.Text + "', city='" + txtCiudad.Text + "' where id=" + Session["id"] + "";
                SqlCommand cmd = new SqlCommand(sql, con.conn);
                cmd.ExecuteNonQuery();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertScript", "alert('Actualización Éxitosa')", true);
                clear();
            }
            catch (System.FormatException)
            {
                lblMsg.Text = "Revise el formato de los campos";
            }
            catch(System.Web.HttpException)
            {
                lblMsg.Text = "Error de actualizar";
            }
            finally
            {
                con.conn.Close();
                display();
            }
            
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                lblMsg.Text = "";
                val1.Enabled = false;
                val2.Enabled = false;
                con.conn.Open();
                string sql = "delete partner where id=" + Session["id"] + "";
                SqlCommand cmd = new SqlCommand(sql,con.conn);
                cmd.ExecuteNonQuery();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertScript", "alert('Eliminación Éxitosa')", true);
                clear();
            }
            catch (System.FormatException)
            {
                lblMsg.Text = "Revise el formato de los campos";
            }
            catch(System.Web.HttpException)
            {
                lblMsg.Text = "Error de eliminación";
            }
            finally
            {
                con.conn.Close();
                display();
            } 
           
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            Session["id"] = btn.CommandArgument;
            try
            {
                lblMsg.Text = "";
                val1.Enabled = false;
                val2.Enabled = false;
                con.conn.Open();
                string sql = "select * from partner where id=" + Session["id"] + "";
                SqlCommand cmd = new SqlCommand(sql, con.conn);
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                if (dt.Rows.Count >= 0)
                {
                    txtNombre.Text = dt.Rows[0]["name"].ToString();
                    txtApellidos.Text = dt.Rows[0]["lastName"].ToString();
                    txtCalle.Text = dt.Rows[0]["street"].ToString();
                    txtNoExt.Text = dt.Rows[0]["noExt"].ToString();
                    txtNoInt.Text = dt.Rows[0]["noInt"].ToString();
                    txtTelefono.Text = dt.Rows[0]["phone"].ToString();
                    txtMovil.Text = dt.Rows[0]["movil"].ToString();
                    txtCP.Text = dt.Rows[0]["cp"].ToString();
                    txtEstado.Text = dt.Rows[0]["state"].ToString();
                    txtCiudad.Text = dt.Rows[0]["city"].ToString();

                }
            }
            catch (System.FormatException)
            {
                lblMsg.Text = "Revise el formato de los campos";
            }
            catch (System.Web.HttpException)
            {
                lblMsg.Text = "Error de seleccionar";
            }
            finally
            {
                con.conn.Close();
            }
 
        }

        public void display()
        {
            try
            {
                lblMsg.Text = "";
                val1.Enabled = false;
                val2.Enabled = false;
                con.conn.Open();
                string sql = "select * from partner";
                SqlCommand cmd = new SqlCommand(sql, con.conn);
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                grid1.DataSource = dt;
                grid1.DataBind();
            }
            catch (System.FormatException)
            {
                lblMsg.Text = "Error de consultar";
            }
            catch (System.Web.HttpException)
            {
                lblMsg.Text = "Error de consultar";
            }
            finally
            {
                con.conn.Close();
            }
        }


        public void clear()
        {
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtCalle.Text = "";
            txtNoExt.Text = "";
            txtNoInt.Text = "";
            txtTelefono.Text = "";
            txtMovil.Text = "";
            txtCP.Text = "";
            txtEstado.Text = "";
            txtCiudad.Text = "";
            val1.Enabled = false;
            val2.Enabled = false;
        }
    }
}