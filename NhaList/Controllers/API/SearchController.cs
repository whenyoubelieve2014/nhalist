using System;
using System.Linq;
using System.Web.Http;
using NhaList.Models;

namespace NhaList.Controllers.API
{
    public class SearchController : ApiController
    {
        private readonly INhaListEntityProvider _provider;

        public SearchController(INhaListEntityProvider provider)
        {
            if (provider == null) throw new ArgumentNullException("provider");
            _provider = provider;
        }

        // POST api/post
        public PostCollection Post([FromBody] dynamic boundary)
        {
            if (boundary == null || boundary.minLat==null)
            {
                return new PostCollection();
            }
            double minLat = boundary.minLat;
            double minLong = boundary.minLong;
            double maxLat = boundary.maxLat;
            double maxLong = boundary.maxLong;
            IQueryable<Post> posts = _provider.Db.Post
                .Where(p => minLat < p.Latitude
                            && p.Latitude < maxLat
                            && minLong < p.Longtitude
                            && p.Longtitude < maxLong
                );
            return new PostCollection(posts);
        }
    }
}