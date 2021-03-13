using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CitasMedicas_UniCode.Models.ModelCustom
{
    public class Process
    {

        [Key]
        public int IdProcess { get; set; }
        public string ProcessName { get; set; }
        public double Price { get; set; }

        public int IdTreatment { get; set; }
        public virtual Treatment Treatment { get; set; }

        public virtual ICollection<MedicalAppointments> MedicalAppointments { get; set; }
    }
}