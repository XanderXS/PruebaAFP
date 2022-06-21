using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Prueba.Modelo.Model
{
    public partial class Citum
    {
        public Citum()
        {
            Diagnosticos = new HashSet<Diagnostico>();
        }

        public int CitaId { get; set; }
        public int? DoctorId { get; set; }
        public int? PacienteId { get; set; }
        public DateTime? FechaHora { get; set; }
        [JsonIgnore]
        public virtual Doctor Doctor { get; set; }
        [JsonIgnore]
        public virtual Paciente Paciente { get; set; }
        [JsonIgnore]
        public virtual ICollection<Diagnostico> Diagnosticos { get; set; }
    }
}
