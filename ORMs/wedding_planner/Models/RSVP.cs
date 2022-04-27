using System;
using System.ComponentModel.DataAnnotations;

namespace wedding_planner.Models
{
    public class RSVP
    {
        [Key]
        public int GuestId {get;set;}
        public int UserId {get;set;}
        public User Attendee {get;set;}
        public int WeddingId {get;set;}
        public Wedding Wedding {get;set;}
        public int NumOfGuests {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}