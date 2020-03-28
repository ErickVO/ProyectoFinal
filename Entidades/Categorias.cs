using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudioEA.Entidades
{
   public class Categorias
    {
        [Key]
        public int CategoriasId { get; set; }
        public int UsuarioId { get; set; }
        public string NombreCategorias { get; set; }

        public Categorias()
        {
            CategoriasId = 0;
            UsuarioId = 0;
            NombreCategorias = string.Empty;
        }
    }
}
