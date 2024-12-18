﻿using SchoolSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
namespace SchoolSystem.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InstractorStudent>()
                .HasKey(x => new { x.StudentId, x.InstractorId});
            modelBuilder.Entity<Instractor>()
                .HasMany(i => i.Students)
                .WithMany(i => i.Instractors)
                .UsingEntity<InstractorStudent>();


            modelBuilder.Entity<Subject>().HasData(
                new Subject { SubjectId = 1, Name = "Arabic" },
                new Subject { SubjectId = 2, Name = "Math" },
                new Subject { SubjectId = 3, Name = "English" },
                new Subject { SubjectId = 4, Name = "Physics" },
                new Subject { SubjectId = 5, Name = "Social Studies" }
                );
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Instractor> Instractors { get; set; }
        public DbSet<InstractorStudent> InstractorStudents { get; set; }
    }
}
