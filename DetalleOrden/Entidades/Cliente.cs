using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DetalleOrden.Entidades
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public Cliente()
        {
            ClienteId = 0;
            Nombre = string.Empty;
            Direccion = string.Empty;
        }

    }
}
