using System;
using EFCoreDemo.Factories;
using EFCoreDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFCoreDemo.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base()
        {

        }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }

        public bool IsUseCoursePartition { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine($"OnConfiguring:{this.GetHashCode()}");
            optionsBuilder
                .UseMySql("Server=192.168.3.127;Port=3306;Database=ContosoUniversityContext;Uid=root;Pwd=123456;")
                .ReplaceService<IModelCacheKeyFactory, DynamicModelCacheKeyFactory>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Console.WriteLine($"OnModelCreating:{GetHashCode()}");
            modelBuilder.Entity<Course>().ToTable(IsUseCoursePartition ? "Course01" : "Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Department>().ToTable("Department");
        }
    }
}