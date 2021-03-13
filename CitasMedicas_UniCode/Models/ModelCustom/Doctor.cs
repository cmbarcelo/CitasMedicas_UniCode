using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CitasMedicas_UniCode.Models.ModelCustom
{
    public class Doctor
    {
        [Key]
        public int IdDoctor{ get; set; }
        public string NameDoctor { get; set; }
        public int? Telephone { get; set; }
        public string Specialty { get; set; }

        public int IdConsultory { get; set; }
        public virtual Consultory Consultory { get; set; }

        public virtual ICollection<MedicalAppointments> MedicalAppointments { get; set; }
    }
}