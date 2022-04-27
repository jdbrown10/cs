using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace chefs_and_dishes.Models
{
    public class Dish
    {
    [Key]
    public int DishId {get;set;}
    [Required]

    public string Name {get;set;}
    [Required]

    public int NumOfCalories {get;set;}
    [Required]

    public string Description {get;set;}
    [Required]

    public int Tastiness {get;set;}

    public int ChefId {get;set;} //this is the foreign key for the Chef class! but MySql doesn't know to treat it as a foreign key if you don't include the navigation property. If you forget it you will prob have to drop your tables and start over =(

    //Navigation property - like a bookmark for the other table

    public Chef Creator {get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
        
    }

}