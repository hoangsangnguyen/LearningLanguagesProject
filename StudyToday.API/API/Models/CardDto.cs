using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class CardDto : BaseDto
    {
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public Guid CardTypeId { get; set; }
        public string CardTypeName { get; set; }

        public string Content { get; set; }

        public string Voice { get; set; }
        public int OrderIndex { get; set; }

        public Guid LessonId { get; set; }
        public string LessonName { get; set; }

        public string CreatorName { get; set; }
        public string CreatedAt { get; set; }

        public bool Deleted { get; set; }
    }
}
