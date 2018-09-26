using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class PostDto : BaseDto
    {
        public int NumberOfLike { get; set; }
        public string ImageUrl { get; set; }

        public string Content { get; set; }
        public Guid UserId { get; set; }
        public virtual string UserName { get; set; }

        public string CreatedAt { get; set; }

        public bool Deleted { get; set; }
    }
}
