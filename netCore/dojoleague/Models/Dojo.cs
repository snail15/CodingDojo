using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace dojoleague.Models {
    public class Dojo : BaseEntity{

        [Key]
        public long Id {get; set;}

        [Required]
        public string Name {get; set;}

        [Required(ErrorMessage="We have to know where it is")]
        public string Location {get; set;}

        [Required(ErrorMessage="Provide additional info on the Dojo")]
        public string Description {get; set;}

         public ICollection<Ninja> Ninjas { get; set; }

    }
}