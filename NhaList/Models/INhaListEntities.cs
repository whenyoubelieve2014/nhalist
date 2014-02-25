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
        DbSet<GeoSearch> GeoSearches { get; set; }
        DbSet<Post> Posts { get; set; }
        int SaveChanges();
        void LogToDebuggerOutput();
    }

    public partial class NhaListEntities : INhaListDbContext
    {
        public override int SaveChanges()
        {
            try
            {
                int result = base.SaveChanges();
                Debug.Flush();
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

        public void LogToDebuggerOutput()
        {
            Trace.WriteLine("LogToDebuggerOutput Starting new instance of NhaListEntities");
            Database.Log = msg => Trace.WriteLine(msg);
        }
    }
}