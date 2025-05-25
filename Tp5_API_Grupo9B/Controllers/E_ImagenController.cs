using Entidades;
using Logica;
using Logica.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace Tp5_API_Grupo9B.Controllers
{
    public class E_ImagenController : ApiController
    {
        [HttpPost]
        [Route("api/imagenes/agregar")]
        public HttpResponseMessage AgregarImagenes(int idArticulo, [FromBody] List<string> imagenes)
        {
            try
            {
                L_Imagen logica = new L_Imagen();
                L_Articulo logicaArt = new L_Articulo();

                if (logicaArt.ExisteId(idArticulo))
                {
                    foreach (string url in imagenes)
                    {

                        if (!logica.ExisteImagenEnBD(url))
                        {
                            logica.AgregarImg(idArticulo, url);
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.Conflict, "La imagen ya existe");
                        }
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, "Imágenes agregadas correctamente.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "El id no existe");
                }

            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ocurrió un error al agregar las imágenes.");
            }
        }


        // GET: api/E_Imagen/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/E_Imagen
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/E_Imagen/5
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete]
        [Route("api/imagenes/eliminar")]
        public HttpResponseMessage Delete(int id)
        {
            L_Imagen l_Imagen = new L_Imagen();

            L_Articulo l_Articulo = new L_Articulo();

            try
            {
                if (l_Articulo.ExisteId(id))
                {
                    var lista = l_Imagen.ListarImagenesPorID(id);

                    bool existe = lista.Any(x => x.IdArticulo == id);
                    if (existe)
                    {
                        l_Imagen.EliminarFisico(id);
                        return Request.CreateResponse(HttpStatusCode.OK, "Imagen eliminada correctamente.");

                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "El id no tiene imagenes.");
                    }

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "El id de articulo no existe.");
                }
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ocurrio un error inesperado.");
            }


        }
    }
}
