using System;
using System.ComponentModel.DataAnnotations;

namespace mvc_demo.Models
{
    public class User
    {
        //now that we're dealing with a model, we need to provide each of the attributes with extra permission (get;set;)
        [Required]
        public string Name {get;set;}

        [Required]
        [MinLength(3, ErrorMessage="Must be at least 3 characters!")]
        public string FavColor {get;set;}

        [Required]
        [Range(-2000, 2000)]
        public int FavNumber {get;set;}

    }
}