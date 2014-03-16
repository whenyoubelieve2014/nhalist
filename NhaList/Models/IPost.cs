using System;

namespace NhaList.Models
{
    public interface IPost
    {
        int Id { get; set; }
        string Phone { get; set; }
        string Email { get; set; }
        string Text { get; set; }
        DateTime CreatedOn { get; set; }
    }

    public partial class Post : IPost
    {
    }
}