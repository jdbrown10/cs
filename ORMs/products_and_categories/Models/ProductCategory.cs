using System;
using System.ComponentModel.DataAnnotations;

namespace products_and_categories.Models
{
    public class ProductCategory
    {

        [Key]
        public int ProductCategoryId {get;set;}

        public int ProductId {get;set;}
        public int CategoryId {get;set;}


        //this is just a bookmark -> we won't actually store this data 
        public Product Product {get;set;}
        public Category Category {get;set;}
    }
}

//this is the joining table for the many-to-many!