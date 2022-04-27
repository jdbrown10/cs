using System;
using System.ComponentModel.DataAnnotations;

namespace Dojo_Survey_With_Validation.Models
{
    public class User
    {
        //now that we're dealing with a model, we need to provide each of the attributes with extra permission (get;set;)
        [Required]
        [MinLength(2, ErrorMessage="Name must be at least 2 characters!")]
        public string Name {get;set;}

        [Required]
        public string DojoLocation {get;set;}

        [Required]
        public string FavoriteLanguage {get;set;}
        [MinLength(21, ErrorMessage="A comment isn't required, but if you've got one, it should be more than 20 characters!")]
        public string Comment {get;set;}

    }
}
