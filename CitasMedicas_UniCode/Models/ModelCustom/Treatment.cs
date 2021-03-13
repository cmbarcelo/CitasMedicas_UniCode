using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CitasMedicas_UniCode.Models.ModelCustom
{
    public class Treatment
    {
        [Key]
        public int IdTreatment { get; set; }
        public string TreatmentName { get; set; }

        public virtual ICollection<Process> Processes { get; set; }
        public virtual ICollection<Treatment> Treatments { get; set; }
    }
}