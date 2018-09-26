using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class CommentDto : BaseDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }

        public string Content { get; set; }
        public Guid PostId { get; set; }
        public string PostName { get; set; }

        public string CreatedAt { get; set; }

        public bool Deleted { get; set; }
    }
}
