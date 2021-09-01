using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BartenderApp.Models
{
    public class Bartender
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Drink")]
        public string DrinkName { get; set; }

        [Required]
        public decimal Price { get; set; }

    }
}
