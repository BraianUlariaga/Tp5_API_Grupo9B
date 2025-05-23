using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tp5_API_Grupo9B.Models
{
    public class Imagen
    {

        public int Id { get; set; }

        public int IdArticulo { get; set; }

        public string ImagenUrl { get; set; }
    }
}