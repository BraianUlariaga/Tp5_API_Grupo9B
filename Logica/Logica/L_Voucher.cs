using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Logica
{
    public class L_Voucher
    {

        public bool ExisteVoucher(string codigoVoucher)
        {
            ConexionSql conexion = new ConexionSql();

            try
            {
                conexion.Consulta("SELECT COUNT(*) FROM Vouchers WHERE CodigoVoucher = @CodigoVoucher");
                conexion.SetParametros("@CodigoVoucher", codigoVoucher);

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


        public bool VoucherVigente(string codigoVoucher)
        {
            ConexionSql conexion = new ConexionSql();

            try
            {
                conexion.Consulta("SELECT COUNT(*) FROM Vouchers WHERE CodigoVoucher = @CodigoVoucher and IdCliente is null");
                conexion.SetParametros("@CodigoVoucher", codigoVoucher);

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


        public bool ArticuloVinculadoAVoucher(int idArt)
        {
            ConexionSql conexion = new ConexionSql();

            try
            {
                // Modificar la consulta para verificar ambos parámetros
                conexion.Consulta("SELECT COUNT(*) FROM Vouchers WHERE IdArticulo = @IdArticulo");

                // Establecer los parámetros
                conexion.SetParametros("@IdArticulo", idArt);


                // Ejecutar la consulta
                conexion.Ejecutar();

                // Leer el resultado de la consulta
                if (conexion.Lector.Read())
                {
                    int cantidad = Convert.ToInt32(conexion.Lector[0]);
                    if (cantidad > 0)
                        return true; // Si se encuentra el idArticulo con el codigo, el voucher está vinculado
                }

                return false; // Si no se encuentra el idArticulo con el codigo
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
            
            public bool RegistrarCanje(E_Vouchers voucher)
            {
                ConexionSql conexion = new ConexionSql();

                try
                {
                    conexion.Consulta("UPDATE VOUCHERS SET IdCliente = @IdCliente, FechaCanje = @FechaCanje, IdArticulo = @IdArticulo WHERE CodigoVoucher = @CodigoVoucher");

                    conexion.SetParametros("@CodigoVoucher", voucher.CodigoVoucher);
                    conexion.SetParametros("@IdCliente", voucher.IdCliente);
                    conexion.SetParametros("@FechaCanje", voucher.FechaCanje ?? DateTime.Now); // usa ahora si no se especifica
                    conexion.SetParametros("@IdArticulo", voucher.IdArticulo);

                    conexion.EjecutarAccion();
                    return true;
                }
                catch (Exception ex)
                {
                    // Podés loguear o relanzar según tu necesidad
                    return false;
                }
                finally
                {
                    conexion.cerrarConexion();
                }
            }





    }
}
