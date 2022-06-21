using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Prueba.Modelo.Model
{
    public partial class Diagnostico
    {
        public int DiagnosticoId { get; set; }
        public int? CitaId { get; set; }
        public string Resumen { get; set; }
        [JsonIgnore]
        public virtual Citum Cita { get; set; }
    }
}
