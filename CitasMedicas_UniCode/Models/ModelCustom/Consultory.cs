using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CitasMedicas_UniCode.Models.ModelCustom
{
    public class Consultory
    {
        [Key]
        public int IdConsultory { get; set; }
        public string ConsultoryName { get; set; }
        public string ConsultoryEmail { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<MedicalAppointments> MedicalAppointments { get; set; }
    }
}