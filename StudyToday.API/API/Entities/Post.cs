using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Post : BaseEntity
    {
        public int NumberOfLike { get; set; }
        public string ImageUrl { get; set; }

        public string Content { get; set; }
        public Guid UserId { get; set; }
        public virtual UserEntity User { get; set; }

        public bool Deleted { get; set; }

        private ICollection<Comment> _comments;

        public virtual ICollection<Comment> Comments
        {
            get => _comments ?? (_comments = new List<Comment>());
            set => _comments = value;
        }
    }
}
