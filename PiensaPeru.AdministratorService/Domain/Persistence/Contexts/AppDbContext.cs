using Microsoft.EntityFrameworkCore;
using PiensaPeru.AdministratorService.Domain.Models;
using PiensaPeru.AdministratorService.Extensions;

namespace PiensaPeru.AdministratorService.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Person>? People { get; set; }
        public DbSet<Content>? Contents { get; set; }
        public DbSet<Administrator>? Administrators { get; set; }
        public DbSet<Management>? Managements { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Person Entity
            modelBuilder.Entity<Person>().ToTable("People");

            // Constraints
            modelBuilder.Entity<Person>().HasKey(p => p.Id);
            modelBuilder.Entity<Person>().HasDiscriminator(p => p.PersonType).IsComplete(false);
            modelBuilder.Entity<Person>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Person>().Property(p => p.FirstName).IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.LastName).IsRequired();

            // Aministrator Constraints
            modelBuilder.Entity<Administrator>().Property(a => a.Email).HasColumnName("email").IsRequired();
            modelBuilder.Entity<Administrator>().Property(a => a.Password).HasColumnName("password").IsRequired();

            // Administrator Seed Data
            modelBuilder.Entity<Administrator>().HasData
                (
                    new Administrator
                    {
                        Id = 102,
                        FirstName = "Juan",
                        LastName = "Pérez",
                        Email = "juan.perez@gmail.com",
                        Password = "password123"
                    },

                    new Administrator
                    {
                        Id = 103,
                        FirstName = "Gloria",
                        LastName = "Ramps",
                        Email = "gloria.ramos@gmail.com",
                        Password = "password123"
                    }
                );

            // Content Entity
            modelBuilder.Entity<Content>().ToTable("Contents");

            // Content Constraints
            modelBuilder.Entity<Content>().HasKey(c => c.Id);
            modelBuilder.Entity<Content>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Content>().Property(c => c.Active).IsRequired();

            // Content Seed Data
            modelBuilder.Entity<Content>().HasData
                (
                    new Content
                    {
                        Id = 100,
                        Active = true
                    },

                    new Content
                    {
                        Id = 101,
                        Active = true
                    },

                    new Content
                    {
                        Id = 102,
                        Active = true
                    },

                    new Content
                    {
                        Id = 103,
                        Active = true
                    },

                    new Content
                    {
                        Id = 104,
                        Active = true
                    },

                    new Content
                    {
                        Id = 105,
                        Active = true
                    },

                    new Content
                    {
                        Id = 106,
                        Active = true
                    }
                );

            // Management Entity
            modelBuilder.Entity<Management>().ToTable("Managements");

            // Management Constraints
            modelBuilder.Entity<Management>().HasKey(m => m.Id);
            modelBuilder.Entity<Management>().Property(m => m.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Management>().Property(m => m.ManagementType).IsRequired();
            modelBuilder.Entity<Management>().Property(m => m.AdministratorId).IsRequired();
            modelBuilder.Entity<Management>().Property(m => m.ContentId).IsRequired();

            // Management Seed Data
            modelBuilder.Entity<Management>().HasData
                (
                    new Management
                    {
                        Id = 100,
                        ManagementType = "Type 1",
                        AdministratorId = 102,
                        ContentId = 100
                    },

                    new Management
                    {
                        Id = 101,
                        ManagementType = "Type 1",
                        AdministratorId = 102,
                        ContentId = 101
                    },

                    new Management
                    {
                        Id = 102,
                        ManagementType = "Type 1",
                        AdministratorId = 102,
                        ContentId = 102
                    },

                    new Management
                    {
                        Id = 103,
                        ManagementType = "Type 1",
                        AdministratorId = 101,
                        ContentId = 103
                    }
                );

            modelBuilder.Entity<Content>()
                .HasMany(c => c.Managements)
                .WithOne(m => m.Content)
                .HasForeignKey(m => m.ContentId);

            modelBuilder.Entity<Administrator>()
                .HasMany(a => a.Managements)
                .WithOne(p => p.Administrator)
                .HasForeignKey(p => p.AdministratorId);

            modelBuilder.ApplySnakeCaseNamingConvention();
        }
    }
}