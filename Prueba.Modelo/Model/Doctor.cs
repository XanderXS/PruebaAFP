using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Prueba.Modelo.Model
{
    public partial class Doctor
    {
        public Doctor()
        {
            Cita = new HashSet<Citum>();
        }

        public int DoctorId { get; set; }
        public string Nombre { get; set; }
        public int? TipoId { get; set; }

        [JsonIgnore]
        public virtual TipoDotor Tipo { get; set; }
        [JsonIgnore]
        public virtual ICollection<Citum> Cita { get; set; }
    }
}
