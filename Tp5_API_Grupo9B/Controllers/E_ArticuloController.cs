using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Entidades;
using Logica;
using Logica.Logica;
using Tp5_API_Grupo9B.Models;


namespace Tp5_API_Grupo9B.Controllers
{
    public class E_ArticuloController : ApiController
    {
        // GET: api/E_Articulo
        [HttpGet]
        [Route("api/articulos/listar")]
        public HttpResponseMessage ListarArticulos()
        {
            try
            {
                L_Articulo l_Articulo = new L_Articulo();
                var lista = l_Articulo.Listar();

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ocurrio un error inesperado.");
            }
        }

        // GET: api/E_Articulo/5
        [HttpGet]
        [Route("api/articulos/buscarPorID")]
        public HttpResponseMessage ListarPorID(int id)
        {
            L_Articulo logica = new L_Articulo();

            try
            {
                if (logica.ExisteId(id))
                {
                    E_Articulo articulo = logica.ListarPorID(id);
                    return Request.CreateResponse(HttpStatusCode.OK, articulo);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Articulo no encontrado.");
                }
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ocurrio un error inesperado.");
            }
        }


        [HttpGet]
        [Route("api/articulos/buscarArticulo")]
        public HttpResponseMessage Buscar(string Nombre = null, string Codigo = null, int? IdMarca = null, int? IdCategoria = null)
        {
            try
            {
                L_Articulo logica = new L_Articulo();

                var lista = logica.Buscar(Nombre, Codigo, IdMarca, IdCategoria);

                if (lista != null && lista.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, lista);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No se encontraron articulos que coincidan con los criterios de busqueda.");
                }
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ocurrio un error inesperado.");
            }

        }


        // POST: api/E_Articulo
        [HttpPost]
        [Route("api/articulos/agregar")]
        public HttpResponseMessage AgregarArticulo([FromBody] E_ArticuloDTO art)
        {
            try
            {

                L_Articulo logica = new L_Articulo();
                var lista = logica.Listar();
                bool existe = lista.Any(x => x.Codigo == art.Codigo);
                if (!existe)
                {
                    E_Articulo aux = new E_Articulo();
                    aux.Codigo = art.Codigo;
                    aux.Nombre = art.Nombre;
                    aux.Descripcion = art.Descripcion;
                    aux.Precio = art.Precio;
                    aux.Marca = new E_Marca();
                    aux.Marca.Id = art.idMarca;
                    aux.Categoria = new E_Categoria();
                    aux.Categoria.Id = art.idCategoria;
                    logica.Agregar(aux);

                    return Request.CreateResponse(HttpStatusCode.OK, "Articulo agregado correctamente.");
                }
                else
                {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "El codigo de articulo ya existe.");
                }
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ocurrio un error inesperado.");
            }
        }



        // PUT: api/E_Articulo/5
        [HttpPut]
        [Route("api/articulos/modificar")]
        public HttpResponseMessage ModificarArticulo(int id, [FromBody] E_ArticuloDTO art)
        {

            try
            {
                L_Articulo logica = new L_Articulo();

                if (logica.ExisteId(id))
                {
                    E_Articulo aux = new E_Articulo();
                    aux.Codigo = art.Codigo;
                    aux.Nombre = art.Nombre;
                    aux.Descripcion = art.Descripcion;
                    aux.Precio = art.Precio;
                    aux.Marca = new E_Marca();
                    aux.Marca.Id = art.idMarca;
                    aux.Categoria = new E_Categoria();
                    aux.Categoria.Id = art.idCategoria;
                    aux.IdArt = id;
                    logica.Modificar(aux);

                    return Request.CreateResponse(HttpStatusCode.OK, "Articulo modificado correctamente.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Articulo no encontrado.");
                }
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ocurrio un error inesperado.");
            }
        }

        // DELETE: api/E_Articulo/5
        [HttpDelete]
        [Route("api/articulos/eliminarArticulo")]
        public HttpResponseMessage EliminarArticulo(int id)
        {
            try
            {
                L_Articulo logica = new L_Articulo();

                if (logica.ExisteId(id))
                {
                    logica.EliminarFisico(id);
                    return Request.CreateResponse(HttpStatusCode.OK, "Articulo eliminado correctamente.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Articulo no encontrado.");
                }

            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ocurrio un error inesperado.");
            }
        }

    }

}
