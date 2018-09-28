using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Lesson : BaseEntity
    {
        public string Title { get; set; }

        public string Introduction { get; set; }

        public Guid TopicId { get; set; }
        public virtual Topic Topic { get; set; }

        private ICollection<Card> _cards;

        public virtual ICollection<Card> Cards
        {
            get => _cards ?? (_cards = new List<Card>());
            set => _cards = value;
        }
    }
}
