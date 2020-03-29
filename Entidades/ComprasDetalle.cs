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
        public int ComprasId { get; set; }
        public int ArticulosId { get; set; }
        public int CantidadArticulos { get; set; }
        public decimal Costo { get; set; }


        public ComprasDetalle()
        {
            ComprasDetalleId = 0;
            ComprasId = 0;
            ArticulosId = 0;
            CantidadArticulos = 0;
            Costo = 0;
        }

        public ComprasDetalle(int comprasId,int articulosId, int cantidadArticulos, int costo)
        {
            ComprasDetalleId = 0;
            ComprasId = comprasId;
            ArticulosId = articulosId;
            CantidadArticulos = cantidadArticulos;
            Costo = costo;
        }
    }
}
