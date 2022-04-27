using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace products_and_categories.Models
{
    public class Product
    {

        [Key]
        public int ProductId {get;set;}

        [Required]
        public String Name {get;set;}
        [Required]
        public String Description {get;set;}
        [Required]

        public int Price {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        
        //this will just be a list of all of the associated category IDs
        public List<ProductCategory> CategoriesIncludedIn {get;set;}
    }
}