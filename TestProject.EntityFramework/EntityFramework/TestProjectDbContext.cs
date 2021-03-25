using System.Data.Common;
using System.Data.Entity;
using Abp.DynamicEntityParameters;
using Abp.Json;
using Abp.Zero.EntityFramework;
using TestProject.Authorization.Roles;
using TestProject.Authorization.Users;
using TestProject.Entities;
using TestProject.MultiTenancy;

namespace TestProject.EntityFramework
{
    public class TestProjectDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE:
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */

        public TestProjectDbContext()
            : base("Default")
        {
        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in TestProjectDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of TestProjectDbContext since ABP automatically handles it.
         */

        public TestProjectDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        //This constructor is used in tests
        public TestProjectDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {
        }

        public TestProjectDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {
        }

        /// <summary>
        /// 人員
        /// </summary>
        public virtual IDbSet<Person> Persons { get; set; }

        /// <summary>
        /// 車輛
        /// </summary>
        public virtual IDbSet<Vehicle> Vehicle { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DynamicParameter>().Property(p => p.ParameterName).HasMaxLength(250);
            modelBuilder.Entity<EntityDynamicParameter>().Property(p => p.EntityFullName).HasMaxLength(250);

            modelBuilder.Entity<Person>().Property(p => p.Name).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Vehicle>().Property(p => p.PersonId).IsRequired();

        }
    }
}