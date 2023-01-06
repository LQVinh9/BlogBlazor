using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebBlog.Models
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Posts = new HashSet<Post>();
        }

        public string UserId { get; set; } = null!;
        public string? UserName { get; set; }
        public string? Mail { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public bool? IsDisable { get; set; }
        public string? RoleId { get; set; }

        public virtual Role? Role { get; set; }

        [JsonIgnore]
        public virtual ICollection<Comment> Comments { get; set; }
        [JsonIgnore]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
