using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD_demo.Models
{
    public class Pet
    {
        [Key]
        public int PetId {get;set;} //highly recommended to use the name of your class in the name of your ID
        [Required]
        public string Name {get;set;}
        [Required]
        public string Species {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}