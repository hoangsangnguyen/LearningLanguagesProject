using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Comment : BaseEntity
    {
        public Guid UserId { get; set; }
        public virtual UserEntity User { get; set; }

        public string Content { get; set; }
        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public bool Deleted { get; set; }

    }
}
