using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace dATABASE.Data
{
    class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            builder.UseSqlite(@"DataSource=myDatabase.sqlite");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Student>() //dalšíomezení přes fluent
                .Property(p => p.FirstName)
                .HasMaxLength(100);
            builder.Entity<Classroom>().HasData( //db Seed
                new Classroom { Id = 1, Name = "P3"}
                );
            builder.Entity<Student>().HasData( //db Seed
                new Student {
                    Id = 1,
                    FirstName = "Jennifer",
                    LastName = "Mária Gibaštíková",
                    ClassroomId = 1}
                );
        }
        
    }
}
