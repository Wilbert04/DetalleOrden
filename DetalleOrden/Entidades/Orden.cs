using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DetalleOrden.Entidades
{
    public class Orden
    {
        [Key]
        public int OrdenId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId{ get; set; }
        public decimal Monto { get; set; }
        public virtual List<OrdenDetalle> Ordenes{ get; set; }

        public Orden()
        {
            OrdenId = 0;
            Fecha = DateTime.Now;
            ClienteId = 0;
            Monto = 0;
            Ordenes = new List<OrdenDetalle>();
        }
    }
}
