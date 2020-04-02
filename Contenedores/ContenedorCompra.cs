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
       // public List<ListaCompra> listaPagos { get; set; }

        public ContenedorCompra()
        {
            compras = new Compras();
            comprasDetalle = new ComprasDetalle();
           // listaPagos = new List<ListaCompra>();
        }
    }
}
