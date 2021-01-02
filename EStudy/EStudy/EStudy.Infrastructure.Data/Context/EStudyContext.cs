using EStudy.Domain.Models;
using EStudy.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EStudy.Infrastructure.Data.Context
{
    public class EStudyContext : DbContext
    {
        private const string WinLocalSqlConn = "Server=(localdb)\\MSSQLLocalDB;Database=EStudyDb;Trusted_Connection=True;";
        private string SqliteConn = $"EStudy.db";

        public DbSet<User> Users { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonFile> LessonFiles { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<HomeworkFile> HomeworkFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new EmailConfiguration());
            modelBuilder.ApplyConfiguration(new FileConfiguration());
            modelBuilder.ApplyConfiguration(new UniversityConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new SpecialtyConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new GroupMemberConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new LessonFileConfiguration());
            modelBuilder.ApplyConfiguration(new HomeworkConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(SqliteConn);
            //optionsBuilder.UseSqlServer(WinLocalSqlConn);
        }
    }
}