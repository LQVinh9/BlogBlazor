using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebBlog.Models
{
    public partial class Category
    {
        public Category()
        {
            Posts = new HashSet<Post>();
        }

        public string CategoryId { get; set; } = null!;
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public DateTime? DateCreate { get; set; }
        public bool? IsDisable { get; set; }

        [JsonIgnore]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
