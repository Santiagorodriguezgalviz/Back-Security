using Dapper;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Module = Entity.Model.Security.Module;

namespace Entity.Model.Contexts
{
    public class ApplicationDbContexts : DbContext
    {
        protected readonly IConfiguration _configuration;
        public object Module;
        public object Person;

        public ApplicationDbContexts(DbContextOptions<ApplicationDbContexts> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
               .HasOne(u => u.person)
               .WithMany(p => p.Users)
               .HasForeignKey(u => u.PersonId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Module>()
              .HasMany(m => m.Views)
              .WithOne(v => v.module)
              .HasForeignKey(v => v.ModuleId);

            modelBuilder.Entity<Role_View>()
                .HasKey(rv => rv.Id);

            modelBuilder.Entity<Role_View>()
            .HasOne(rv => rv.role)
            .WithMany(r => r.Role_Views)
            .HasForeignKey(rv => rv.RoleId);

        modelBuilder.Entity<Role_View>()
            .HasOne(rv => rv.view)
            .WithMany(v => v.Role_Views)
            .HasForeignKey(rv => rv.ViewId);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        }


        public readonly struct DapperEFCoreCommand : IDisposable
        {
            public DapperEFCoreCommand(DbContext context, string text, object parameters, int? timeout, CommandType? type, CancellationToken ct)
            {
                var transaction = context.Database.CurrentTransaction?.GetDbTransaction();
                var commandType = type ?? CommandType.Text;
                var commandTimeout = timeout ?? context.Database.GetCommandTimeout() ?? 30;

                Definition = new CommandDefinition(
                    text,
                    parameters,
                    transaction,
                    commandTimeout,
                    commandType,
                    cancellationToken: ct);
            }

            public CommandDefinition Definition { get; }

            public void Dispose()
            {
            }
        }

        public override int SaveChanges()
        {
            EnsureAudit();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
            {
            EnsureAudit();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string text, object parameters = null, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryAsync<T>(command.Definition);
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string text, object parameters = null, int? timeout = null, CommandType? type = null)
        {

            using var command = new DapperEFCoreCommand(this, text, parameters, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(command.Definition);
        }



        private void EnsureAudit()
        {
            ChangeTracker.DetectChanges();
        }

        //security

        public DbSet<Role> role => Set<Role>();
        public DbSet<Person> person => Set<Person>();
        public DbSet<User> user => Set<User>();
        public DbSet<Module> module => Set<Module>();
        public DbSet<View> view => Set<View>();
        public DbSet<User_role> user_role => Set<User_role>();
        public DbSet<Role_View> role_view => Set<Role_View>();
        public DbSet<Country> countries => Set<Country>();
        public DbSet<Departament> Departaments => Set<Departament>();
        public DbSet<City> Cities => Set<City>();







    }
}