using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DetalleOrden.Entidades
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        [ForeignKey("ClienteId")]
        public virtual List<Orden> ClienteOrden { get; set; }


        public Cliente()
        {
            ClienteId = 0;
            Nombre = string.Empty;
            Direccion = string.Empty;
            ClienteOrden = new List<Orden>();
        }

    }
}
