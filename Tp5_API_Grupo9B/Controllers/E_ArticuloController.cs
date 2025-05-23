using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entidades;
using Logica;
using Logica.Logica;
using Tp5_API_Grupo9B.Models;


namespace Tp5_API_Grupo9B.Controllers
{
    public class E_ArticuloController : ApiController
    {
        // GET: api/E_Articulo
        public IEnumerable<E_Articulo> Get()
        {
           L_Articulo l_Articulo = new L_Articulo();
            return l_Articulo.Listar();
        }

        // GET: api/E_Articulo/5
        public E_Articulo Get(int id)
        {
            L_Articulo l_Articulo = new L_Articulo();
            E_Articulo articulo = new E_Articulo();
            articulo = l_Articulo.ListarPorID(id);
            return articulo;
        }

        // POST: api/E_Articulo
        public void Post([FromBody]E_ArticuloDTO art)
        {
            L_Articulo logica = new L_Articulo();
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
        }

        // PUT: api/E_Articulo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/E_Articulo/5
        public void Delete(int id)
        {
        }
    }
}
