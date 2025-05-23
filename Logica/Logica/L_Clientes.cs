using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Logica
{
    public class L_Clientes
    {
        public bool ExisteDni(string DNI)
        {
            ConexionSql conexion = new ConexionSql();

            try
            {
                conexion.Consulta("SELECT COUNT(*) FROM Clientes WHERE Documento = @Documento");
                conexion.SetParametros("@Documento", DNI);

                conexion.Ejecutar();

                if (conexion.Lector.Read())
                {
                    int cantidad = Convert.ToInt32(conexion.Lector[0]);
                    if (cantidad > 0)
                        return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }


        public E_Clientes BuscarClientePorDni(string DNI)
        {
            ConexionSql conexion = new ConexionSql();
            E_Clientes cliente = null;

            try
            {
                
                conexion.Consulta("SELECT id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes WHERE Documento = @Documento");
                conexion.SetParametros("@Documento", DNI);

                conexion.Ejecutar();

                if (conexion.Lector.Read())  
                {
                  
                    cliente = new E_Clientes()
                    {
                        id = Convert.ToInt32(conexion.Lector["id"]),
                        Documento = conexion.Lector["Documento"].ToString(),
                        Nombre = conexion.Lector["Nombre"].ToString(),
                        Apellido = conexion.Lector["Apellido"].ToString(),
                        Email = conexion.Lector["Email"].ToString(),
                        Direccion = conexion.Lector["Direccion"].ToString(),
                        Ciudad = conexion.Lector["Ciudad"].ToString(),
                        CP = Convert.ToInt32(conexion.Lector["CP"])
                    };
                }

                return cliente;  
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.cerrarConexion();  
            }
        }

        public bool AgregarCliente(E_Clientes cliente)
        {
            ConexionSql conexion = new ConexionSql();

            try
            {
                conexion.Consulta("INSERT INTO Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) VALUES (@Documento, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CP)");

                conexion.SetParametros("@Documento", cliente.Documento);
                conexion.SetParametros("@Nombre", cliente.Nombre);
                conexion.SetParametros("@Apellido", cliente.Apellido);
                conexion.SetParametros("@Email", cliente.Email);
                conexion.SetParametros("@Direccion", cliente.Direccion);
                conexion.SetParametros("@Ciudad", cliente.Ciudad);
                conexion.SetParametros("@CP", cliente.CP);

                conexion.EjecutarAccion();

                return true;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

    }

}


