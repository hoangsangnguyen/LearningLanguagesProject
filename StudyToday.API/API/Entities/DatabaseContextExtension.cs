using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public static class DatabaseContextExtension
    {
        public static void SeedData(this DatabaseContext context)
        {
            if (context.CardTypes.Count() == 0)
            {
                var cardTypes = new List<CardType>()
                {
                    new CardType
                    {
                        Id = Guid.NewGuid(),
                        Type = "Vocabulary"
                    },
                     new CardType
                     {
                         Id = Guid.NewGuid(),
                         Type = "Main"
                     }
                };

                context.CardTypes.AddRange(cardTypes);
            }
            context.SaveChanges();
        }
    }
}
