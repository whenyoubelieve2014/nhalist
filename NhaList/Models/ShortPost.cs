using System;
using Newtonsoft.Json;
using NhaList.Convenience.ExtensionMethods;

namespace NhaList.Models
{
    public class ShortPost : IPost
    {
        public string NgayDang
        {
            get { return CreatedOn.ToSmartString(); }
        }

        public int Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }

        [JsonIgnore]
        public DateTime CreatedOn { get; set; }
    }
}