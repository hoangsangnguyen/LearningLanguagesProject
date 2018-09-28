using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class LessonForCreationDto
    {
        public string Title { get; set; }

        public string Introduction { get; set; }

        public Guid TopicId { get; set; }
    }
}
