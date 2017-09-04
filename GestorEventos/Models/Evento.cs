using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestorEventos.Models {
    public class Evento {
        [Key]
        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string Prioridad { get; set; }
    }
}