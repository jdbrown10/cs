using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace chefs_and_dishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId {get;set;}
        [Required]
        [MinLength(2)]

        public String FirstName {get;set;}
        [Required]
        [MinLength(2)]
        public String LastName {get;set;}
        [Required]
        public DateTime DateOfBirth {get;set;}

        // Navigation property - this is the one side, so we're expecting many dishes 
        public List<Dish> Repertoire {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}