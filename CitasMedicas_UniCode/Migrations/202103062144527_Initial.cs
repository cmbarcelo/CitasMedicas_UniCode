namespace CitasMedicas_UniCode.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consultories",
                c => new
                    {
                        IdConsultory = c.Int(nullable: false, identity: true),
                        ConsultoryName = c.String(),
                        ConsultoryEmail = c.String(),
                    })
                .PrimaryKey(t => t.IdConsultory);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        IdDoctor = c.Int(nullable: false, identity: true),
                        NameDoctor = c.String(),
                        Telephone = c.Int(),
                        Specialty = c.String(),
                        IdConsultory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDoctor)
                .ForeignKey("dbo.Consultories", t => t.IdConsultory, cascadeDelete: true)
                .Index(t => t.IdConsultory);
            
            CreateTable(
                "dbo.MedicalAppointments",
                c => new
                    {
                        IdMedicalAppointments = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        IdDoctor = c.Int(),
                        IdConsultory = c.Int(),
                        IdPatient = c.Int(),
                        IdTreatment = c.Int(),
                        IdProcess = c.Int(),
                    })
                .PrimaryKey(t => t.IdMedicalAppointments)
                .ForeignKey("dbo.Consultories", t => t.IdConsultory)
                .ForeignKey("dbo.Doctors", t => t.IdDoctor)
                .ForeignKey("dbo.Patients", t => t.IdPatient)
                .ForeignKey("dbo.Processes", t => t.IdProcess)
                .ForeignKey("dbo.Treatments", t => t.IdTreatment)
                .Index(t => t.IdDoctor)
                .Index(t => t.IdConsultory)
                .Index(t => t.IdPatient)
                .Index(t => t.IdTreatment)
                .Index(t => t.IdProcess);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        IdPatient = c.Int(nullable: false, identity: true),
                        CURP = c.String(),
                        Name = c.String(),
                        Telephone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPatient);
            
            CreateTable(
                "dbo.Processes",
                c => new
                    {
                        IdProcess = c.Int(nullable: false, identity: true),
                        ProcessName = c.String(),
                        Price = c.Double(nullable: false),
                        IdTreatment = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProcess)
                .ForeignKey("dbo.Treatments", t => t.IdTreatment, cascadeDelete: true)
                .Index(t => t.IdTreatment);
            
            CreateTable(
                "dbo.Treatments",
                c => new
                    {
                        IdTreatment = c.Int(nullable: false, identity: true),
                        TreatmentName = c.String(),
                        Treatment_IdTreatment = c.Int(),
                    })
                .PrimaryKey(t => t.IdTreatment)
                .ForeignKey("dbo.Treatments", t => t.Treatment_IdTreatment)
                .Index(t => t.Treatment_IdTreatment);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IdConsultory = c.Int(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Consultories", t => t.IdConsultory)
                .Index(t => t.IdConsultory)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "IdConsultory", "dbo.Consultories");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.MedicalAppointments", "IdTreatment", "dbo.Treatments");
            DropForeignKey("dbo.Treatments", "Treatment_IdTreatment", "dbo.Treatments");
            DropForeignKey("dbo.Processes", "IdTreatment", "dbo.Treatments");
            DropForeignKey("dbo.MedicalAppointments", "IdProcess", "dbo.Processes");
            DropForeignKey("dbo.MedicalAppointments", "IdPatient", "dbo.Patients");
            DropForeignKey("dbo.MedicalAppointments", "IdDoctor", "dbo.Doctors");
            DropForeignKey("dbo.MedicalAppointments", "IdConsultory", "dbo.Consultories");
            DropForeignKey("dbo.Doctors", "IdConsultory", "dbo.Consultories");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "IdConsultory" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Treatments", new[] { "Treatment_IdTreatment" });
            DropIndex("dbo.Processes", new[] { "IdTreatment" });
            DropIndex("dbo.MedicalAppointments", new[] { "IdProcess" });
            DropIndex("dbo.MedicalAppointments", new[] { "IdTreatment" });
            DropIndex("dbo.MedicalAppointments", new[] { "IdPatient" });
            DropIndex("dbo.MedicalAppointments", new[] { "IdConsultory" });
            DropIndex("dbo.MedicalAppointments", new[] { "IdDoctor" });
            DropIndex("dbo.Doctors", new[] { "IdConsultory" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Treatments");
            DropTable("dbo.Processes");
            DropTable("dbo.Patients");
            DropTable("dbo.MedicalAppointments");
            DropTable("dbo.Doctors");
            DropTable("dbo.Consultories");
        }
    }
}
