using System;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Text;

namespace NhaList.Models
{
    public interface INhaListDbContext : IDisposable
    {
        DbSet<GeoSearch> GeoSearch { get; set; }
        DbSet<Post> Post { get; set; }
        int SaveChanges();
    }

    public interface ITracedDbContext
    {
        void LogToTrace();
    }

    public partial class NhaListEntities : INhaListDbContext
    {
        protected NhaListEntities(string sqlConnStringName) : base(sqlConnStringName)
        {
        }

        public override int SaveChanges()
        {
            try
            {
                int result = base.SaveChanges();
                return result;
            }
            catch (DbEntityValidationException validationException)
            {
                var sb = new StringBuilder("EF validation failed: ");
                foreach (DbEntityValidationResult validationErrors in validationException.EntityValidationErrors)
                {
                    foreach (DbValidationError validationError in validationErrors.ValidationErrors)
                    {
                        sb.AppendFormat("Property: {0} Error: {1}", validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }
                string msg = sb.ToString();
                Trace.WriteLine(msg);
                throw new EntityCommandExecutionException(msg, validationException);
            }
        }


        protected void CallOnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class TracedNhaListEntities : NhaListEntities, ITracedDbContext
    {
        public TracedNhaListEntities()
        {
            LogToTrace();
        }

        public void LogToTrace()
        {
            Trace.WriteLine(string.Format("LogToTrace Starting new instance of {0}", GetType()));
            Database.Log = msg => Trace.Write(msg);
        }
    }
}