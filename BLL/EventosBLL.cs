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
    public class EventosBLL
    {
        public static bool Guardar(Eventos eventos)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                if (db.Eventos.Add(eventos) != null)
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

        public static bool Modificar(Eventos eventos)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Entry(eventos).State = EntityState.Modified;
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
                var eliminar = db.Eventos.Find(id);
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

        public static Eventos Buscar(int id)
        {
            Contexto db = new Contexto();
            Eventos eventos = new Eventos();

            try
            {
                eventos = db.Eventos.Include(x => x.VentasDetalle).
                    Where(x => x.EventosId == id)
                    .SingleOrDefault();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return eventos;
        }

        public static List<Eventos> GetList(Expression<Func<Eventos, bool>> eventos)
        {
            Contexto db = new Contexto();
            List<Eventos> listado = new List<Eventos>();

            try
            {
                listado = db.Eventos.Where(eventos).ToList();
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
