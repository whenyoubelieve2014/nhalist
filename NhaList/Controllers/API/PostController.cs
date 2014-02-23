using System.Collections.Generic;
using System.Web.Http;

namespace NhaList.Controllers.API
{
    public class PostController : ApiController
    {
        // GET api/post
        public IEnumerable<string> Get()
        {
            return new[] {"value1", "value2"};
        }

        // GET api/post/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/post
        public void Post([FromBody] string value)
        {
        }

        // PUT api/post/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/post/5
        public void Delete(int id)
        {
        }
    }
}