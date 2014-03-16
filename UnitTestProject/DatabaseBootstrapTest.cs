using System.Data.Entity;
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
            DatabaseBootstrap.Initialise<MigrationDb>();
            Conveniently.VerifyModelAccuracy(new NhaListEntities(), Assert.Fail);
        }

        public class MigrationDb : NhaListEntities
        {
            public MigrationDb()
                : base("DbMigration")
            {
            }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.CallOnModelCreating(modelBuilder);
            }
        }
    }
}