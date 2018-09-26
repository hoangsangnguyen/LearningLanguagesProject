using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Card : BaseEntity
    {
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public Guid CardTypeId { get; set; }
        public virtual CardType CardType { get; set; }

        public string Content { get; set; }

        public string Voice { get; set; }
        public int OrderIndex { get; set; }

        public Guid LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public bool Deleted { get; set; }
    }
}
