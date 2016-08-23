using ChiangMaiUniversity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ChiangMaiUniversity.DAL
{
    public class ChiangMaiUniversityContext : DbContext
    {
        public ChiangMaiUniversityContext() : base("ChiangMaiUniversityContext")
        {
            //this.Configuration.ProxyCreationEnabled = false;
            //this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ValidateOnSaveEnabled = false;
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Code First also do it for you but we need to set it
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Instructors).WithMany(i => i.Courses)
                .Map(t => t.MapLeftKey("CourseID")
                    .MapRightKey("InstructorID")
                    .ToTable("CourseInstructor"));
            modelBuilder.Entity<Instructor>()
                .HasOptional(i => i.OfficeAssignment).WithRequired(o => o.Instructor);
            // Instruct EF to use stored procedures
            modelBuilder.Entity<Department>().MapToStoredProcedures();
            // Add concerrency token
            //modelBuilder.Entity<Department>()
            //    .Property(d => d.RowVersion).IsConcurrencyToken();
        }
    }
}