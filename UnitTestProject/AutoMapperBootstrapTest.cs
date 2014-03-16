using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NhaList;
using NhaList.Models;

namespace UnitTestProject
{
    [TestClass]
    public class AutoMapperBootstrapTest
    {
        [TestInitialize]
        public void Init()
        {
            AutoMapperBootstrap.Initialise();
        }
        [TestMethod]
        public void InitialiseTest_WhenMapEmptyPostToShortPost_ShouldBeOK()
        {
            var post = new Post();
            var shortPost = Mapper.Map<ShortPost>(post);
            Assert.IsInstanceOfType(shortPost, typeof(ShortPost));
        }
        [TestMethod]
        public void InitialiseTest_WhenMapNonEmptyPostToShortPost_ShouldBeOK()
        {
            var post = new Post
            {
                Id = int.MaxValue,
                Phone = Fast.Phone,
                FormattedAddress = "thanh pho 123123"
            };
            var shortPost = Mapper.Map<ShortPost>(post);
            Assert.IsInstanceOfType(shortPost, typeof(ShortPost));
            Assert.AreEqual(shortPost.Id, int.MaxValue);
            Assert.AreEqual(shortPost.Phone, Fast.Phone);
        }
    }
}