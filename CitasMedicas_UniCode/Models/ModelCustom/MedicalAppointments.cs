using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CitasMedicas_UniCode.Models.ModelCustom
{
    public class MedicalAppointments
    {
        [Key]
        public int IdMedicalAppointments { get; set; }
        public DateTime Date { get; set; }

        public int? IdDoctor { get; set; }
        public virtual Doctor Doctor { get; set; }

        public int? IdConsultory { get; set; }
        public virtual Consultory Consultory { get; set; }

        public int? IdPatient { get; set; }
        public virtual Patient Patient { get; set; }

        public int? IdTreatment { get; set; }
        public virtual Treatment Treatment { get; set; }

        public int? IdProcess { get; set; }
        public virtual Process Process { get; set; }
    }
}