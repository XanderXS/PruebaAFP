using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Prueba.Modelo.Model
{
    public partial class TipoDotor
    {
        public TipoDotor()
        {
            Doctors = new HashSet<Doctor>();
        }

        public int TipoId { get; set; }
        public string TipoNombre { get; set; }
        public string TipoDescripcion { get; set; }
        [JsonIgnore]
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
