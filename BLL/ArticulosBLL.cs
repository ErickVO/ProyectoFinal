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

        public static Articulos Buscar(int id)
        {
            Contexto db = new Contexto();
            Articulos articulos = new Articulos();

            try
            {
                articulos = db.Articulos.Include(x => x.ComprasDetalle).
                    Where(x => x.ArticuloId == id).
                    SingleOrDefault();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return articulos;
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

        public static void StockSuma(int id, decimal cantidad, decimal costo)
        {
            Articulos articulos = Buscar(id);

            articulos.Stock += cantidad;
            articulos.Costo = costo;

            Modificar(articulos);
        }

        public static bool StockResta(int id, decimal cantidad)
        {
            Articulos articulos = Buscar(id);

            articulos.Stock -= cantidad;

            if (articulos.Stock >= 0)
            {
                Modificar(articulos);
                return true;
            }
            else
                return false;
        }

        public static String ObtenerDescripcion(int id)
        {
            Articulos articulo = Buscar(id);
            if (articulo == null)
                return "No existe el producto";
            else
                return articulo.Descripcion;
        }

        public static decimal ObtenerPrecio(int id)
        {
            Articulos articulo = Buscar(id);
            if (articulo == null)
                return 0.0m;
            else
                return articulo.Precio;
        }

        public static decimal ObtenerCantidad(int id)
        {
            Articulos articulo = Buscar(id);
            if (articulo == null)
                return 0.0m;
            else
                return articulo.Stock;
        }

    }
}
