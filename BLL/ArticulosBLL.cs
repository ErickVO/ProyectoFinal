using Microsoft.EntityFrameworkCore;
using StudioEA.DAL;
using StudioEA.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace StudioEA.BLL
{
   public class ArticulosBLL
    {
        public static bool Guardar(Articulos articulos)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                if (db.Articulos.Add(articulos) != null)
                {
                    paso = (db.SaveChanges() > 0);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Articulos articulos)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Entry(articulos).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                var eliminar = db.Articulos.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Categorias Buscar(int id)
        {
            Contexto db = new Contexto();
            Categorias categorias = new Categorias();

            try
            {
                categorias = db.Categorias.Find(id);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return categorias;
        }

        public static List<Articulos> GetList(Expression<Func<Articulos, bool>> articulos)
        {
            Contexto db = new Contexto();
            List<Articulos> listado = new List<Articulos>();

            try
            {
                listado = db.Articulos.Where(articulos).ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return listado;
        }

    }
}
