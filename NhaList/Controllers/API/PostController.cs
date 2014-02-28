using System;
using System.Collections.Generic;
using System.Web.Http;
using NhaList.Models;

namespace NhaList.Controllers.API
{
    public class PostController : ApiController
    {
        //// GET api/post
        //public IEnumerable<string> Get()
        //{
        //    return new[] {"value1", "value2"};
        //}

      

        private readonly INhaListEntityProvider _provider;

        public PostController(INhaListEntityProvider provider)
        {
            if (provider == null) throw new ArgumentNullException("provider");
            _provider = provider;
        }

        // POST api/post
        public void Post([FromBody] Post post)
        {
            if (post == null) throw new ArgumentNullException("post");

            post.CreatedOn = DateTime.Now;
            _provider.Db.Posts.Add(post);
            _provider.Db.SaveChanges();
        }

        //// PUT api/post/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/post/5
        //public void Delete(int id)
        //{
        //}
    }
}