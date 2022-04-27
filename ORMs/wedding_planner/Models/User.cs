using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace wedding_planner.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}

        //other features
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password {get;set;}
        [Required]
        public string FirstName {get;set;}
        [Required]
        public string LastName {get;set;}
        [Required]
        [EmailAddress]
        public string Email {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        //Connect to one to many
        public List<Wedding> WeddingsPlanned {get;set;}

        //Connect to many to many
        public List<RSVP> MyRSVPs {get;set;}

        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string Confirm {get;set;}
    }
}
