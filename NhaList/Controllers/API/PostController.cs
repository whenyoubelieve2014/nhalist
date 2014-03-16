using System;
using System.Web.Http;
using NhaList.Models;

namespace NhaList.Controllers.API
{
    public class PostController : ApiController
    {
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
            _provider.Db.Post.Add(post);
            _provider.Db.SaveChanges();
        }

    }
}