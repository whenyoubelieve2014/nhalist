using System;
using System.Linq;
using System.Web.Http;
using NhaList.Convenience.ExtensionMethods;
using NhaList.Convenience.Types;
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
        public IHttpActionResult Post([FromBody] Post post)
        {
            if (post == null) return BadRequest("post is null");

            return Conveniently.Try<IHttpActionResult>(() =>
            {
                post.CreatedOn = DateTime.Now;
                _provider.Db.Post.Add(post);
                _provider.Db.SaveChanges();
                return Ok();
            }, error =>
                InternalServerError(new DataOperationException(
                    string.Format("Cannot save post<{0}>", post.ToJson()), error)));
        }

        // GET api/post
        [Queryable]
        public IQueryable<Post> Get(string password)
        {
            if (password != "2C324A02-A980-4BA6-BB10-A3B45886067F")
            {
                return null;
            }
            return _provider.Db.Post.AsQueryable();
        }

        //// DELETE api/post
        //public int Delete(string password)
        //{
        //    if (password != "2C324A02-A980-4BA6-BB10-A3B45886067F")
        //    {
        //        return int.MinValue;
        //    }
        //    _provider.Db.Post.RemoveRange(_provider.Db.Post);
        //    return _provider.Db.SaveChanges();
        //}
    }
}