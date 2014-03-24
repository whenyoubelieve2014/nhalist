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
        private const string MAGIC_WORD = "2C324A02-A980-4BA6-BB10-A3B45886067F";
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
            return Conveniently.Try(() => password != MAGIC_WORD ? null : _provider.Db.Post.AsQueryable());
        }

        // DELETE api/post
        public IHttpActionResult Delete(string password)
        {
            return password != MAGIC_WORD
                ? (IHttpActionResult) NotFound()
                : Conveniently.Try(() =>
                {
                    _provider.Db.Post.RemoveRange(_provider.Db.Post);
                    return Ok(_provider.Db.SaveChanges());
                });
        }
    }
}