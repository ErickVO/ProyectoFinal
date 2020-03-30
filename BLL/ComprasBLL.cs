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
    public class ComprasBLL
    {
        public static bool Guardar(Compras compras)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                if (db.Compras.Add(compras) != null)
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

        public static bool Modificar(Compras compras)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Database.ExecuteSqlRaw($"DELETE FROM ComprasDetalle Where CompraId={compras.CompraId}");

                foreach (var item in compras.ComprasDetalle)
                {
                    db.Entry(item).State = EntityState.Added;
                }

                db.Entry(compras).State = EntityState.Modified;
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
                var eliminar = db.Compras.Find(id);
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

        public static Compras Buscar(int id)
        {
            Contexto db = new Contexto();
            Compras compras = new Compras();

            try
            {
                compras = db.Compras.Include(x=> x.ComprasDetalle).
                    Where(x => x.CompraId == id).
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
            return compras;
        }

        public static List<Compras> GetList(Expression<Func<Compras, bool>> compras)
        {
            Contexto db = new Contexto();
            List<Compras> listado = new List<Compras>();

            try
            {
                listado = db.Compras.Where(compras).ToList();
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
