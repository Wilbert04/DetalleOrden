using DetalleOrden.DAL;
using DetalleOrden.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DetalleOrden.BLL
{
    public class OrdenBLL
    {

        public static bool Guardar(Orden orden)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.ordenTable.Add(orden) != null)
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

        public static bool Modificar(Orden orden)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {

                db.Database.ExecuteSqlRaw($"Delete FROM OrdenDetalle Where OrdenId={orden.OrdenId}");
                foreach( var item in orden.Ordenes)
                {
                    db.Entry(item).State = EntityState.Added;
                }

                db.Entry(orden).State = EntityState.Modified;
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

        public static Orden Buscar(int id)
        {
            Orden orden = new Orden();
            Contexto db = new Contexto();

            try
            {
                orden = db.ordenTable.Where(o => o.OrdenId == id)
                    .Include(o => o.Ordenes).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return orden;

        }


        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.ordenTable.Find(id);
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

    }
}
