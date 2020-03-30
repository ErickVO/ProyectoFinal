using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudioEA.Entidades
{
   public class Categorias
    {
        [Key]
        public int CategoriaId { get; set; }
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }



        public Categorias()
        {
            CategoriaId = 0;
            UsuarioId = 0;
            Nombre = string.Empty;
        }
    }
}
