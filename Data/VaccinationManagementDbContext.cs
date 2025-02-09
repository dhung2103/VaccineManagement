using System.Data.Entity;
using VaccineManagement.Model;

namespace VaccinationManagement.Data
{
    public class VaccinationManagementContext : DbContext
    {
        public VaccinationManagementContext() : base("name=VaccinationManagementConnection")
        {
            Database.SetInitializer<VaccinationManagementContext>(null);
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Children> Children { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<VaccinationPackage> VaccinationPackages { get; set; }
        public DbSet<PackageVaccine> PackageVaccines { get; set; }
        public DbSet<VaccinationRecord> VaccinationRecords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Configure relationships for Children
            // FOREIGN KEY (CreatedBy) REFERENCES Staff(StaffId)
            modelBuilder.Entity<Children>()
                .HasRequired(c => c.CreatedByStaff)
                .WithMany(s => s.CreatedChildren)
                .HasForeignKey(c => c.CreatedBy)
                .WillCascadeOnDelete(false);
            #endregion

            #region Configure composite key for PackageVaccine
            modelBuilder.Entity<PackageVaccine>()
                .HasKey(pv => new { pv.PackageId, pv.VaccineId });

            // Configure relationships for PackageVaccine
            modelBuilder.Entity<PackageVaccine>()
                .HasRequired(pv => pv.Package)
                .WithMany(p => p.PackageVaccines)
                .HasForeignKey(pv => pv.PackageId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PackageVaccine>()
                .HasRequired(pv => pv.Vaccine)
                .WithMany(v => v.PackageVaccines)
                .HasForeignKey(pv => pv.VaccineId)
                .WillCascadeOnDelete(false);
            #endregion

            #region Configure relationships for VaccinationRecord

            // FOREIGN KEY(ChildId) REFERENCES Children(ChildId),
            modelBuilder.Entity<VaccinationRecord>()
                .HasRequired(vr => vr.Child)
                .WithMany(c => c.VaccinationRecords)
                .HasForeignKey(vr => vr.ChildId)
                .WillCascadeOnDelete(false);

            // FOREIGN KEY(VaccineId) REFERENCES Vaccines(VaccineId),
            modelBuilder.Entity<VaccinationRecord>()
                .HasOptional(vr => vr.Vaccine)
                .WithMany(v => v.VaccinationRecords)
                .HasForeignKey(vr => vr.VaccineId)
                .WillCascadeOnDelete(false);

            // FOREIGN KEY(AdministeredBy) REFERENCES Staff(StaffId)
            modelBuilder.Entity<VaccinationRecord>()
                .HasOptional(vr => vr.AdministeredByStaff)
                .WithMany(s => s.VaccinationRecords)
                .HasForeignKey(vr => vr.AdministeredBy)
                .WillCascadeOnDelete(false);

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}