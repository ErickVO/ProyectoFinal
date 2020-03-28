using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudioEA.Entidades
{
    public class ComprasDetalle
    {
        [Key]
        public int ComprasDetalleId { get; set; }
        public int ArticulosId { get; set; }
        public int CantidadArticulos { get; set; }
        public DateTime Fecha { get; set; }

        public ComprasDetalle()
        {
            ComprasDetalleId = 0;
            ArticulosId = 0;
            CantidadArticulos = 0;
            Fecha = DateTime.Now;
        }

        public ComprasDetalle(int articulosId, int cantidadArticulos, DateTime fecha)
        {
            ComprasDetalleId = 0;
            ArticulosId = articulosId;
            CantidadArticulos = cantidadArticulos;
            Fecha = fecha;
        }
    }
}
