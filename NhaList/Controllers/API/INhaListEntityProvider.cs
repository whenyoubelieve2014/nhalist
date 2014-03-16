using System;
using System.Diagnostics;
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
        }

        public void Dispose()
        {
            Db.SaveChanges();
            Db.Dispose();
            Trace.WriteLine("Disposed NhaListEntityProvider, Db");
        }

        public INhaListDbContext Db { get; private set; }
    }
}