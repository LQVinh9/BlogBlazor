using System;
using System.Collections.Generic;

namespace WebBlog.Models
{
    public partial class Comment
    {
        public string CommentId { get; set; } = null!;
        public string? Content { get; set; }
        public DateTime? DateCreate { get; set; }
        public bool? IsDisable { get; set; }
        public string? PostId { get; set; }
        public string? UserId { get; set; }

        public virtual Post? Post { get; set; }
        public virtual User? User { get; set; }
    }
}
