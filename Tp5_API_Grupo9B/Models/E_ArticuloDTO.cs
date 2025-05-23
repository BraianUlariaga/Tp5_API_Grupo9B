using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tp5_API_Grupo9B.Models
{
    public class E_ArticuloDTO
    {
       
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int idMarca { get; set; }
        public int idCategoria { get; set; }

    }
}