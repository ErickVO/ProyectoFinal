using Microsoft.EntityFrameworkCore;
using StudioEA.DAL;
using StudioEA.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace StudioEA.BLL
{
    public class ClientesBLL
    {
        public static bool Guardar(Clientes cliente)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Clientes.Add(cliente) != null)
                    paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Clientes cliente)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(cliente).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
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
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.Clientes.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Clientes Buscar(int id)
        {
            Clientes cliente = new Clientes();
            Contexto db = new Contexto();

            try
            {
                cliente = db.Clientes.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return cliente;
        }

        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> cliente)
        {
            List<Clientes> Lista = new List<Clientes>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Clientes.Where(cliente).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }

        public static String ObtenerNombre(int id)
        {
            Clientes cliente = Buscar(id);
            String Nombre = cliente.Nombres;
            return Nombre;
        }

        public static String ObtenerApellido(int id)
        {
            Clientes cliente = Buscar(id);
            String Apellido = cliente.Apellidos;
            return Apellido;
        }
    }
}
