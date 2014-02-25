using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using NhaList.Models;

namespace NhaList.Controllers.API
{
    public class GeoSearchController : ApiController
    {
        private readonly INhaListEntityProvider _provider;

        public GeoSearchController(INhaListEntityProvider provider)
        {
            if (provider == null) throw new ArgumentNullException("provider");
            _provider = provider;
        }

        // GET api/GeoSearch
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        // GET api/GeoSearch/address
        /// <summary>
        ///     find lat/long for a given address
        /// </summary>
        /// <param name="data">address to search</param>
        /// <returns>lat/long</returns>
        public GeoSearch Get(string data)
        {
            using (var db = new NhaListEntities())
            {
                GeoSearch result = db.GeoSearches.FirstOrDefault(
                    g => string.Compare(g.AddressToSearch, data, StringComparison.OrdinalIgnoreCase) == 0);
                return result;
            }
        }

        // POST api/GeoSearch
        public void Post([FromBody] GeoSearch result)
        {
            _provider.Db.GeoSearches.Add(result);
            _provider.Db.SaveChanges();
        }

        //// PUT api/GeoSearch/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/GeoSearch/5
        //public void Delete(int id)
        //{
        //}
    }
}