using System.Web.Http;
using AutoMapper;
using NhaList.Models;

namespace NhaList
{
    public class AutoMapperBootstrap
    {
        public static void Initialise()
        {
            Mapper.CreateMap<Post, ShortPost>();
            Mapper.AssertConfigurationIsValid();
        }
    }
  
}