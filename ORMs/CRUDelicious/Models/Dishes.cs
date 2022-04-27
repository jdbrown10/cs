using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        public int DishId {get;set;}
        [Required]

        public String Name {get;set;}
        [Required]

        public String Chef {get;set;}
        [Required]
        [Range(1, 5)]

        public int Tastiness {get;set;}
        [Required]
        [Range(1, 2000)]

        public int Calories {get;set;}
        [Required]

        public String Description {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}