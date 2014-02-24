using System.Collections.Generic;
using System.Web.Http;

namespace NhaList.Controllers.API
{
    public class GeoSearchController : ApiController
    {
        // GET api/GeoSearch
        public IEnumerable<string> Get()
        {
            return new[] {"value1", "value2"};
        }

        // GET api/GeoSearch/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/GeoSearch
        public void GeoSearch([FromBody] string value)
        {
        }

        // PUT api/GeoSearch/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/GeoSearch/5
        public void Delete(int id)
        {
        }
    }
}