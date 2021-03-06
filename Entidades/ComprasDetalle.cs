﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudioEA.Entidades
{
    public class ComprasDetalle
    {
        [Key]
        public int ComprasDetalleId { get; set; }
        public int CompraId { get; set; }
        public int ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public decimal CantidadArticulos { get; set; }
        public decimal Costo { get; set; }


        public ComprasDetalle()
        {
            ComprasDetalleId = 0;
            CompraId = 0;
            ArticuloId = 0;
            CantidadArticulos = 0;
            Costo = 0;
        }

        public ComprasDetalle(int comprasId,int articulosId, decimal cantidadArticulos, decimal costo)
        {
            ComprasDetalleId = 0;
            CompraId = comprasId;
            ArticuloId = articulosId;
            CantidadArticulos = cantidadArticulos;
            Costo = costo;
        }
    }
}
