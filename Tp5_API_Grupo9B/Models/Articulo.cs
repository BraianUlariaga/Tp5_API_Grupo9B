using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tp5_API_Grupo9B.Models
{
    public class Articulo
    {

        public int IdArt { get; set; }
        public int IdMarca { get; set; }
        public int IdCategoria { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public Imagen ImagenUrl { get; set; }

    }
}