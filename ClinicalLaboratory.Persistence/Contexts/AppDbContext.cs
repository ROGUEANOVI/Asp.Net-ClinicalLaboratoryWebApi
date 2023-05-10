using ClinicalLaboratory.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection.Emit;

namespace ClinicalLaboratory.Persistence.Contexts
{
    public class AppDbContext : IdentityDbContext<User, Role, string>
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnectionString")!;
        }

        public virtual DbSet<Analysis> Analysis { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region User
            List<User> users = new List<User>()
            {
                new User
                {
                    FirstName = "Ovidio",
                    LastName = "Romero",
                    UserName = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    Email = "admin@gmail.com",
                    NormalizedUserName =  "ADMIN@GMAIL.COM"
                },
                new User
                {
                    FirstName = "Pepito",
                    LastName = "Perez",
                    UserName = "pepito@gmail.com",
                    NormalizedUserName = "PEPITO@GMAIL.COM",
                    Email = "pepito@gmail.com",
                    NormalizedEmail = "PEPITO@GMAIL.COM"
                },
                new User
                {
                    FirstName = "Juanita",
                    LastName = "Jimenez",
                    UserName = "juanita@gmail.com",
                    NormalizedUserName = "JUANITA@GMAIL.COM",
                    Email = "juanita@gmail.com",
                    NormalizedEmail = "JUANITA@GMAIL.COM",
                }

            };

            modelBuilder.Entity<User>().HasData(users);

            var passwordHasher = new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "$PassAdmin0000");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "$PassPepito0000");
            users[2].PasswordHash = passwordHasher.HashPassword(users[2], "$PassJuanita0000");
            #endregion

            #region Role
            List<Role> roles = new List<Role>()
            {
                new Role {
                    Name = "admin",
                    NormalizedName = "ADMIN",
                },
                new Role
                {
                    Name = "patient",
                    NormalizedName = "PATIENT",
                }

            };

            modelBuilder.Entity<Role>().HasData(roles);
            #endregion

            #region UserRole
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(r => r.Name == "admin").Id
            });

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[1].Id,
                RoleId = roles.First(r => r.Name == "patient").Id
            });

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[2].Id,
                RoleId = roles.First(r => r.Name == "patient").Id
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion

            #region Analysis

            List<Analysis> analysis = new List<Analysis>()
            {
                new Analysis
                {
                    AnalysisId = 1,
                    Name = "PSA",
                    State = 1,
                    AuditCreateDate = DateTime.Now,
                },
                new Analysis
                {
                    AnalysisId = 2,
                    Name = "Hemograma",
                    State = 1,
                    AuditCreateDate = DateTime.Now,
                }
            };

            modelBuilder.Entity<Analysis>(entity =>
            {
                entity.ToTable("Analysis");

                entity.HasKey(e => e.AnalysisId);
                entity.Property(e => e.AnalysisId)
                    .HasColumnName("AnalysisId");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("varchar")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.State)
                    .HasColumnName("State")
                    .HasColumnType("int")
                    .IsRequired();

                entity.Property(e => e.AuditCreateDate)
                    .HasColumnName("AuditCreateDate")
                    .HasColumnType("datetime2(7)");

                entity.HasData(analysis);
            });
            #endregion

            base.OnModelCreating(modelBuilder);
        }


        public IDbConnection CreateConnection => new SqlConnection(_connectionString);
    }
}
