using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CitasMedicas_UniCode.Models.ModelCustom
{
    public class Patient
    {
        [Key]
        public int IdPatient { get; set; }
        public string CURP { get; set; }
        public string Name { get; set; }
        public long Telephone { get; set; }

        public virtual ICollection<MedicalAppointments> MedicalAppointments { get; set; }
    }
}