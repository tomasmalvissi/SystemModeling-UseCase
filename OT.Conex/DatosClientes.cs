using OrdenesDeTrabajo.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT.Conex
{
    public class DatosClientes : DatosConexion
    {
        public int ABMClientes(string accion, Clientes clientes)
        {
            int resultado = 0;
            string orden = string.Empty;

            switch (accion)
            {
                case "Alta":
                    orden = "insert into Clientes " + "values ("
                                            + "'" + clientes.Cuil + "',"
                                            + "'" + clientes.Nombre + "',"
                                            + "'" + clientes.Direccion + "',"
                                            + "'" + clientes.Telefono + "',"
                                            + "'" + clientes.Email + "'"
                                            + ");";
                    break;

                case "Modificar":
                    orden = "update Clientes set "
                                        + "Cuil= '" + clientes.Cuil + "',"
                                        + "Nombre= '" + clientes.Nombre + "',"
                                        + "Direccion= '" + clientes.Direccion + "',"
                                        + "Telefono= '" + clientes.Telefono + "',"
                                        + "Email= '" + clientes.Email + "'"
                                        + "where Id= " + clientes.Id;
                    break;

                case "Eliminar":
                    orden = "Delete from Clientes where DNI = " + clientes.Id;
                    break;
                

            }

            SqlCommand sqlcmd = new SqlCommand(orden, conexion);
            try
            {
                AbrirConex();
                resultado = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception("Error al tratar de moficiar los registros de Clientes", e);
            }
            finally
            {
                CerrarConex();
                sqlcmd.Dispose();
            }
            return resultado;
        }

        public DataSet MostrarClientes(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")
                orden = "select * from Clientes where Id = " + int.Parse(cual) + ";";
            else
                orden = "select * from Clientes;";

            SqlCommand sqlcmd = new SqlCommand(orden, conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                AbrirConex();
                sqlcmd.ExecuteNonQuery();
                da.SelectCommand = sqlcmd;
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("error al listar clientes" , e);
            }
            finally
            {
                CerrarConex();
                sqlcmd.Dispose();
            }
            return ds;
        }
    }
}
