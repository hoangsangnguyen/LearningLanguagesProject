using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class LessonDto : BaseDto
    {
        public string Title { get; set; }

        public string Introduction { get; set; }

        public string CreatedAt { get; set; }

        public Guid TopicId { get; set; }
        public string TopicName { get; set; }
    }
}
