using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Logica.Logica
{
    public class L_Imagen
    {
        

        public void AgregarImg(int id, string url)
        {
            ConexionSql conexion = new ConexionSql();

            try
            {
                conexion.Consulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@Id, @Url)");

                conexion.SetParametros("@Id", id);
                conexion.SetParametros("@Url", url);
   
                conexion.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<E_Imagen> ListarImagenesPorID(int id)
        {
            List<E_Imagen> listaImagenes = new List<E_Imagen>();
            ConexionSql conexion = new ConexionSql();

            try
            {
                
                conexion.Consulta(@"SELECT ImagenUrl, Id as IdImagen, IDArticulo FROM IMAGENES  WHERE IdArticulo = @id");

                conexion.SetParametros("@id", id);  
                conexion.Ejecutar();

                while (conexion.Lector.Read())  
                {
                    E_Imagen imagen = new E_Imagen();
                    imagen.ImagenUrl = (string)conexion.Lector["ImagenUrl"];
                    imagen.Id = (int)conexion.Lector["IdImagen"];
                    imagen.IdArticulo = (int)conexion.Lector["IDArticulo"];
                    listaImagenes.Add(imagen);  
                }

                return listaImagenes;
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

        public void EliminarFisico(int idArticulo)
        {
            ConexionSql conexion = new ConexionSql();

            try
            {
                conexion.Consulta("DELETE FROM IMAGENES WHERE IdArticulo = @IdArticulo");
                conexion.SetParametros("@IdArticulo", idArticulo);
                conexion.Ejecutar();
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


        public bool ExisteImagenEnBD(string url)
        {
            ConexionSql conexion = new ConexionSql();
            try
            {
                // Consulta para verificar si la URL existe en la base de datos
                conexion.Consulta("SELECT COUNT(*) FROM IMAGENES WHERE ImagenUrl = @Url");
                conexion.SetParametros("@Url", url);
                int count = (int)conexion.EjecutarEscalar();
                return count > 0;
            }
            catch (Exception ex)
            {
                // Manejo de errores
                
                return false;
            }
            finally
            {
                // Cerrar la conexión
                conexion.cerrarConexion();
            }
        }

    }
}
