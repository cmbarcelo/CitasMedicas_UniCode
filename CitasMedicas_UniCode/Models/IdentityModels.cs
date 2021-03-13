using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using CitasMedicas_UniCode.Models.ModelCustom;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CitasMedicas_UniCode.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public int? IdConsultory { get; set; }
        public virtual Consultory Consultory { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<CitasMedicas_UniCode.Models.ModelCustom.Consultory> Consultories { get; set; }

        public System.Data.Entity.DbSet<CitasMedicas_UniCode.Models.ModelCustom.Doctor> Doctors { get; set; }

        public System.Data.Entity.DbSet<CitasMedicas_UniCode.Models.ModelCustom.Patient> Patients { get; set; }

        public System.Data.Entity.DbSet<CitasMedicas_UniCode.Models.ModelCustom.Process> Processes { get; set; }

        public System.Data.Entity.DbSet<CitasMedicas_UniCode.Models.ModelCustom.Treatment> Treatments { get; set; }

        public System.Data.Entity.DbSet<CitasMedicas_UniCode.Models.ModelCustom.MedicalAppointments> MedicalAppointments { get; set; }
    }
}