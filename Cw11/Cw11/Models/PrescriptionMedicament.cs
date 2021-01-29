using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cw11.Models
{
    public class PrescriptionMedicament
    {
        public int? IdMedicament { get; set; }
        [JsonIgnore]
        public virtual Medicament Medicament { get; set; }
        [JsonIgnore]
        public int? IdPrescription { get; set; }
        public virtual Prescription Prescription { get; set; }
        public int? Dose { get; set; }
        public string Details { get; set; }
    }
}
