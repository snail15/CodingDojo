using System.Collections.Generic;

namespace weddingplanner2.Models
{
    public class Wedding : BaseEntity {

        public int Id {get; set;}

        public string Name {get; set;}
        public string Date {get; set;}
        public string Location {get; set;}
        public int GuestNumber {get; set;}

        public List<Rsvp> Guests {get; set;}
        public Wedding(){
            Guests = new List<Rsvp>();
        }
        
    }
}