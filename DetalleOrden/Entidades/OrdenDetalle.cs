using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DetalleOrden.Entidades
{
    public class OrdenDetalle
    {
        [Key]
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio{ get; set; }

        public OrdenDetalle()
        {

        }

        public OrdenDetalle(int id, int ordenId, int productoId, decimal cantidad, decimal precio)
        {
            Id = id;
            OrdenId = ordenId;
            ProductoId = productoId;
            Cantidad = cantidad;
            Precio = precio;
            
        }
    }
}
