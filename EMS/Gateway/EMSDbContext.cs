using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using EMS.Models;

namespace EMS.Gateway
{
    public class EMSDbContext:DbContext
    {
        public EMSDbContext()
            : base("EMSDbConnection")
        {
            
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Division>  Divisions { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<PoliceStation> PoliceStations { get; set; }
        public DbSet<Union> Unions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; } 
        public DbSet<Education> Educations { get; set; } 
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<EmployeEducation> EmployeEducations { get; set; }
        public DbSet<EmploymentHistory> EmploymentHistories { get; set; }
        public DbSet<EmployeeTrainingHistory> EmployeeTrainingHistories { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public DbSet<EmployeeLanguage> EmployeeLanguages { get; set; }
        public DbSet<EmployeeCertification> EmployeeCertifications { get; set; }





        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
        
    }
}