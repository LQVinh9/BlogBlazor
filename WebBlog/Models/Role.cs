using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebBlog.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public string RoleId { get; set; } = null!;
        public string? RoleName { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
