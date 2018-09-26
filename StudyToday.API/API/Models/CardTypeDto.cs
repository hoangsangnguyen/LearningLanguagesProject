using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class CardTypeDto : BaseDto
    {
        [Required(ErrorMessage = "Enter type")]
        public string Type { get; set; }

    }
}
