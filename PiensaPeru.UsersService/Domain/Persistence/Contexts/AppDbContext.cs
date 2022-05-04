using Microsoft.EntityFrameworkCore;
using PiensaPeru.UsersService.Domain.Models;
using PiensaPeru.UsersService.Extensions;

namespace PiensaPeru.UsersService.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Person>? People { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Calification>? Califications { get; set; }
        public DbSet<Plan> Plans { get; set; }


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

            // User Constraints
            modelBuilder.Entity<User>().Property(u => u.Email).HasColumnName("email").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).HasColumnName("password").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Subscribed).IsRequired();

            // User Seed Data
            modelBuilder.Entity<User>().HasData
                (
                    new User
                    {
                        Id = 104,
                        FirstName = "Rómulo",
                        LastName = "López",
                        Email = "romulo.lopez@gmail.com",
                        Password = "password123",
                        Subscribed = true
                    },
                    
                    new User
                    {
                        Id = 105,
                        FirstName = "María",
                        LastName = "García",
                        Email = "maria.garcia@gmail.com",
                        Password = "password123",
                        Subscribed = false
                    }
                );

            // Calification Entity
            modelBuilder.Entity<Calification>().ToTable("Califications");

            // Calification Constraints
            modelBuilder.Entity<Calification>().HasKey(c => c.Id);
            modelBuilder.Entity<Calification>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Calification>().Property(c => c.Score).IsRequired();
            modelBuilder.Entity<Calification>().Property(c => c.UserId).IsRequired();

            // Calification Seed Data
            modelBuilder.Entity<Calification>().HasData
                (
                    new Calification
                    {
                        Id = 100,
                        Score = 10,
                        UserId = 104
                    },

                    new Calification
                    {
                        Id = 101,
                        Score = 20,
                        UserId = 104
                    },

                    new Calification
                    {
                        Id = 102,
                        Score = 30,
                        UserId = 104
                    },

                    new Calification
                    {
                        Id = 103,
                        Score = 40,
                        UserId = 104
                    },

                    new Calification
                    {
                        Id = 104,
                        Score = 50,
                        UserId = 104
                    },

                    new Calification
                    {
                        Id = 105,
                        Score = 60,
                        UserId = 105
                    },

                    new Calification
                    {
                        Id = 106,
                        Score = 70,
                        UserId = 105
                    },

                    new Calification
                    {
                        Id = 107,
                        Score = 80,
                        UserId = 105
                    },

                    new Calification
                    {
                        Id = 108,
                        Score = 90,
                        UserId = 105
                    },

                    new Calification
                    {
                        Id = 109,
                        Score = 100,
                        UserId = 105
                    }
                );

            // Plan Entity
            modelBuilder.Entity<Plan>().ToTable("Plans");

            // Plan Constraints
            modelBuilder.Entity<Plan>().HasKey(p => p.UserId);
            modelBuilder.Entity<Plan>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Plan>().Property(p => p.Description).IsRequired();
            modelBuilder.Entity<Plan>().Property(p => p.Price).IsRequired();

            // Plan Seed Data
            modelBuilder.Entity<Plan>().HasData
                (
                    new Plan
                    {
                        UserId = 100,
                        Name = "Plan 1",
                        Description = "Plan 1 Description",
                        Price = 100
                    },

                    new Plan
                    {
                        UserId = 101,
                        Name = "Plan 2",
                        Description = "Plan 2 Description",
                        Price = 200
                    },

                    new Plan
                    {
                        UserId = 102,
                        Name = "Plan 3",
                        Description = "Plan 3 Description",
                        Price = 300
                    }
                );

            // Constraints

            modelBuilder.Entity<User>()
                .HasMany(u => u.Califications)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Plan)
                .WithOne(p => p.User)
                .HasForeignKey<Plan>(p => p.UserId);
            
            modelBuilder.ApplySnakeCaseNamingConvention();
        }
    }
}
