using System.Collections.Generic;

namespace weddingplanner2.Models
{
    public class User : BaseEntity {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        
        public int WeddingId {get; set;}
        public Wedding Wedding {get; set;}
        public List<Rsvp> Rsvps {get; set;}
        public User() {
            Rsvps = new List<Rsvp>();
        }
        
    }
}