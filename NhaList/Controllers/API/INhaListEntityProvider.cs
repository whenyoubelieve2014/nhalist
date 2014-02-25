using System;
using NhaList.Models;

namespace NhaList.Controllers.API
{
    public interface INhaListEntityProvider
    {
        INhaListDbContext Db { get; }
    }

    public class NhaListEntityProvider : INhaListEntityProvider, IDisposable
    {
        public NhaListEntityProvider(INhaListDbContext db)
        {
            if (db == null) throw new ArgumentNullException("db");
            Db = db;
            Db.LogToDebuggerOutput();
        }

        public void Dispose()
        {
            Db.SaveChanges();
            Db.Dispose();
        }

        public INhaListDbContext Db { get; private set; }
    }
}