using DetalleOrden.DAL;
using DetalleOrden.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DetalleOrden.BLL
{
    public class ClienteBLL
    {
        public static bool Guardar(Cliente cliente)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.clienteTable.Add(cliente) != null)
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

        public static bool Modificar(Cliente cliente)
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

        public static Cliente Buscar(int id)
        {
            Cliente cliente = new Cliente();
            Contexto db = new Contexto();

            try
            {
                cliente = db.clienteTable.Find(id);
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


        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.clienteTable.Find(id);
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
