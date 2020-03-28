using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudioEA.Entidades
{
    public class Articulos
    {
        [Key]
        public int ArticulosId { get; set; }
        public int UsuariosId { get; set; }
        public string NombreArticulos { get; set; }
        public string Categorias { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }

        [ForeignKey("ArticulosId")]
        public List<ComprasDetalle> ComprasDetalle { get; set; }

        [ForeignKey("ArticulosId")]
        public List<VentasDetalle> VentasDetalle { get; set; }

        public Articulos()
        {
            ArticulosId = 0;
            UsuariosId = 0;
            NombreArticulos = string.Empty;
            Categorias = string.Empty;
            Stock = 0;
            Precio = 0;

            ComprasDetalle = new List<ComprasDetalle>();
            VentasDetalle = new List<VentasDetalle>();
        }
    }
}
