using StudioEA.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudioEA.Contenedores
{
    public class ContenedorCompra
    {
        public Compras compras { get; set; }
        public ComprasDetalle comprasDetalle { get; set; }
        public List<ListarCompra> listarCompra { get; set; }

        public ContenedorCompra()
        {
            compras = new Compras();
            
            comprasDetalle = new ComprasDetalle();
            
            listarCompra = new List<ListarCompra>();
        }
    }
}
