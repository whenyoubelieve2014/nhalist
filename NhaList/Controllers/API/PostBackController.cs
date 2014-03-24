//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Web.Http;
//using NhaList.Convenience.Types;
//using NhaList.Models;

//namespace NhaList.Controllers.API
//{
//    public class PostBackController : ApiController
//    {
//        private readonly INhaListEntityProvider _provider;

//        public PostBackController(INhaListEntityProvider provider)
//        {
//            if (provider == null) throw new ArgumentNullException("provider");
//            _provider = provider;
//        }

//        // GET api/<controller>
//        public IQueryable<Post> Get()
//        {
//            return Conveniently.Try(() => _provider.Db.Post.AsQueryable());
//        }

//        // GET api/<controller>/5
//        public Post Get(int id)
//        {
//            return Conveniently.Try(() => _provider.Db.Post.Find(id));
//        }

//        // POST api/<controller>
//        public void Post([FromBody] Post value)
//        {
//            Conveniently.Try(() => _provider.Db.Post.Add(value));
//        }

//        // PUT api/<controller>/5
//        public void Put(int id, [FromBody] Post value)
//        {
//            Conveniently.Try(() => _provider.Db.Entry(value).CurrentValues.SetValues(value));
//        }

//        // DELETE api/<controller>/5
//        public void Delete(int id)
//        {
//            Conveniently.Try(() => _provider.Db.Entry(new Post { Id = id }).State = EntityState.Deleted);
//        }
//    }
//}