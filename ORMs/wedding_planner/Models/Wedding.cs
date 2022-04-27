using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace wedding_planner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId {get;set;}
        [Required]

        public String WedderOne {get;set;}
        [Required]
        public String WedderTwo {get;set;}
        [Required]

        public DateTime Date {get;set;}
        [Required]

        public String Address {get;set;}

        //One to many connection

        public int UserId {get;set;}
        public User Planner {get;set;}

        //Many to many connection
        public List<RSVP> GuestRSVPs {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;

        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}