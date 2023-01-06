using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebBlog.Models
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        public string PortId { get; set; } = null!;
        public string? PostName { get; set; }
        public string? ShortDescription { get; set; }
        public string? Content { get; set; }
        public string? Tab { get; set; }
        public string? Image { get; set; }
        public string? Url { get; set; }
        public DateTime? DateCreate { get; set; }
        public bool? IsDisable { get; set; }
        public string? CategoryId { get; set; }
        public string? UserId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual User? User { get; set; }

        [JsonIgnore]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
