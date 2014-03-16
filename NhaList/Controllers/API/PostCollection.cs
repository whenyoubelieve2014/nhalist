using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using NhaList.Models;

namespace NhaList.Controllers.API
{
    public interface IPostCollection
    {
        List<IPost> Posts { get; }
        int Count { get; }
    }


    public class PostCollection : IPostCollection
    {
        public PostCollection(IEnumerable<Post> posts)
        {
            if (posts == null) throw new ArgumentNullException("posts");
            ShortPostAdapter.FromPosts = posts;
            Posts = ShortPostAdapter.ToShortPost;
        }

        public PostCollection()
        {
            Posts = new List<IPost>();
        }

        public List<IPost> Posts { get; private set; }

        public int Count
        {
            get { return Posts != null ? Posts.Count : -1; }
        }
    }

    public class ShortPostAdapter
    {
        public static IEnumerable<Post> FromPosts { get; set; }

        public static List<IPost> ToShortPost
        {
            get
            {
                return FromPosts == null
                    ? null
                    : FromPosts.Select(p => (IPost) Mapper.Map<ShortPost>(p)).ToList();
            }
        }
    }
}