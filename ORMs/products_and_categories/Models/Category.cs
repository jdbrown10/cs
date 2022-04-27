using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace products_and_categories.Models
{
    public class Category
    {
        [Key]
        public int CategoryId {get;set;}

        [Required]
        public String Name {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        //this will just be a list of all of the associated product IDs
        public List<ProductCategory> IncludedProducts {get;set;}
    }
}