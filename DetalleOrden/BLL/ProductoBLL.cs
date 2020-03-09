using DetalleOrden.DAL;
using DetalleOrden.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DetalleOrden.BLL
{
    public class ProductoBLL
    {
        public static bool Guardar(Producto producto)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.productoTable.Add(producto) != null)
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

        public static bool Modificar(Producto producto)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
          
                db.Entry(producto).State = EntityState.Modified;
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

        public static Producto Buscar(int id)
        {
            Producto producto = new Producto();
            Contexto db = new Contexto();

            try
            {
                producto = db.productoTable.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return producto;

        }


        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.productoTable.Find(id);
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
