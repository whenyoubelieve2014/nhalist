using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.DependencyResolution;
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
        public static void Initialise<TEntity>(string connectionStringName) where TEntity : DbContext
        {
            var m = new DbMigrator(new MigrationConfig<TEntity>(connectionStringName));
            m.Update();
        }

        public class MigrationConfig<TEntity> : DbMigrationsConfiguration<TEntity> where TEntity : DbContext
        {
            public MigrationConfig(string connectionName)
            {
                DbConfiguration.LoadConfiguration(typeof(NhaListEntities));
                AutomaticMigrationDataLossAllowed = false;
                AutomaticMigrationsEnabled = true;
                TargetDatabase = new DbConnectionInfo(connectionName);
            }
        }
    }

}