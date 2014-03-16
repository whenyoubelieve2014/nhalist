using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NhaList;
using NhaList.Convenience.Types;
using NhaList.Models;

namespace UnitTestProject
{
    [TestClass]
    public class DatabaseBootstrapTest
    {
        [TestMethod]
        public void InitialiseTest()
        {
            DatabaseBootstrap.Initialise<MigrationDb>(MigrationDb.CONNECTION_STRING_NAME);
            Conveniently.VerifyModelAccuracy(new NhaListEntities(), Assert.Fail);
        }

        public class MigrationDb : NhaListEntities
        {
            public const string CONNECTION_STRING_NAME = "DbMigration";
            public MigrationDb()
                : base(CONNECTION_STRING_NAME)
            {
            }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                CallOnModelCreating(modelBuilder);
            }
        }
    }
}