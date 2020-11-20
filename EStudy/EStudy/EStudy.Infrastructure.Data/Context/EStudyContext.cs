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
        private const string LocalConn = "Server=(localdb)\\MSSQLLocalDB;Database=EStudyDb;Trusted_Connection=True;";

        public DbSet<User> Users { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<IHE> IHEs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new EmailConfiguration());
            modelBuilder.ApplyConfiguration(new FileConfiguration());
            modelBuilder.ApplyConfiguration(new IHEConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new SpecialtyConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new GroupMemberConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(LocalConn);
        }
    }
}