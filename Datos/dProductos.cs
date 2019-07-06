using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;
namespace Datos
{
    public class dProductos
    {
        Database db = new Database();
        public string insertar(eProductos obj)
        {
            try
            {
                SqlConnection con = db.Conecta();
                string insert = string.Format("insert into productos(codigo,descripcion,precio,existencias) values ('{0}','{1}',{2},{3})",obj.Codigo,obj.Descripcion,obj.Precio,obj.Existencias);
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.ExecuteNonQuery();
                return "inserto";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.Desconecta();
            }
        }
        public string modificar(eProductos obj)
        {
            try
            {
                SqlConnection con = db.Conecta();
                string update = string.Format("update productos set descripcion='{0}',precio={1},existencias={2} where codigo='{3}'", obj.Descripcion, obj.Precio, obj.Existencias, obj.Codigo);
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
                return "modifico";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.Desconecta();
            }
        }
        public string eliminar(string codigo)
        {
            try
            {
                SqlConnection con = db.Conecta();
                string delete = string.Format("delete from productos where codigo='{0}'",codigo);
                SqlCommand cmd = new SqlCommand(delete, con);
                cmd.ExecuteNonQuery();
                return "elimino";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.Desconecta();
            }
        }
        public List<eProductos> listartodo()
        {
            try
            {
                List<eProductos> lista = new List<eProductos>();
                eProductos objeto = null;
                SqlConnection con = db.Conecta();
                SqlCommand cmd = new SqlCommand("select codigo,descripcion,precio,existencias from productos",con);
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    objeto = new eProductos();
                    objeto.Codigo = (string)reader["codigo"];
                    objeto.Descripcion = (string)reader["descripcion"];
                    objeto.Precio = (decimal)reader["precio"];
                    objeto.Existencias = (int)reader["existencias"];
                    lista.Add(objeto);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                db.Desconecta();
            }
        }
        public List<eProductos> listarxcriterio(decimal preciop,int existenciasp,int opcion)
        {
            try
            {
                List<eProductos> lista = new List<eProductos>();
                eProductos objeto = null;
                SqlConnection con = db.Conecta();
                string cadenaselect;
                if (opcion == 1)
                    cadenaselect = string.Format("select codigo,descripcion,precio,existencias from productos where precio>{0}",preciop);
                else
                    if(opcion==2)
                    cadenaselect = string.Format("select codigo,descripcion,precio,existencias from productos where existencias<{0}", existenciasp);
                else
                    cadenaselect = string.Format("select codigo,descripcion,precio,existencias from productos where precio>{0} and existencias<{1}", preciop,existenciasp);
                SqlCommand cmd = new SqlCommand(cadenaselect,con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objeto = new eProductos();
                    objeto.Codigo = (string)reader["codigo"];
                    objeto.Descripcion = (string)reader["descripcion"];
                    objeto.Precio = (decimal)reader["precio"];
                    objeto.Existencias = (int)reader["existencias"];
                    lista.Add(objeto);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                db.Desconecta();
            }
        }
    }
}
