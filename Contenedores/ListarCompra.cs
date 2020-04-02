using System;
using System.Collections.Generic;
using System.Text;

namespace StudioEA.Contenedores
{
    public class ListarCompra
    {
        public int CompraId { get; set; }
        public int ArticuloId { get; set; }
        public decimal CantidadArticulos { get; set; }
        public decimal Costo { get; set; }

        public ListarCompra()
        {
            CompraId = 0;
            ArticuloId = 0;
            CantidadArticulos = 0.0m;
            Costo = 0.0m;
        }

        public ListarCompra(int compraId, int articuloId, decimal cantidadArticulos)
        {
            CompraId = compraId;
            ArticuloId = articuloId;
            CantidadArticulos = cantidadArticulos;
            Costo = 0.0m;
        }

        public ListarCompra(int compraId, int articuloId, decimal cantidadArticulos, decimal costo)
        {
            CompraId = compraId;
            ArticuloId = articuloId;
            CantidadArticulos = cantidadArticulos;
            Costo = costo;
        }



    }
}
