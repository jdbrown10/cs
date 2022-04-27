using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace template.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}

        //other features
        [Required]
        [DataType(DataType.Password)]
        public string Password {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string Confirm {get;set;}
    }
}
