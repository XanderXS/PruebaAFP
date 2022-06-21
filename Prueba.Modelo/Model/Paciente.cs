using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Prueba.Modelo.Model
{
    public partial class Paciente
    {
        public Paciente()
        {
            Cita = new HashSet<Citum>();
        }

        public int PacienteId { get; set; }
        public string Nombre { get; set; }

        [JsonIgnore]
        public virtual ICollection<Citum> Cita { get; set; }
    }
}
