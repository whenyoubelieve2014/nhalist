using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using AutoMapper;
using NhaList.Models;

namespace NhaList
{
    public class AutoMapperBootstrap
    {
        public static void Initialise()
        {
            Mapper.CreateMap<Post, ShortPost>();
            Mapper.AssertConfigurationIsValid();
        }
    }

    public class DatabaseBootstrap
    {
        public static void Initialise<TEntity>() where TEntity : DbContext
        {
            var m = new DbMigrator(new MigrationConfig<TEntity>("DbMigration"));
            m.Update();
        }

        public class MigrationConfig<TEntity> : DbMigrationsConfiguration<TEntity> where TEntity : DbContext
        {
            public MigrationConfig(string connectionName)
            {
                AutomaticMigrationsEnabled = true;
                TargetDatabase = new DbConnectionInfo(connectionName);
            }
        }
    }
}