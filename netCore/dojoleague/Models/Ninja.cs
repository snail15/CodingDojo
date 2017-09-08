using System.ComponentModel.DataAnnotations;
using dojoleague.Models;
using System;

namespace dojoleague.Models {
    public class Ninja : BaseEntity{

        [Key]
        public long Id {get; set;}

        [Required(ErrorMessage="You need a name!")]
        public string Name {get; set;}

        [Range(1,11, ErrorMessage="Must be between 1 and 10")]
        public int Level {get; set;}

        [Required]
        public Dojo Dojo {get; set;}

        public string Description {get; set;}




    }
}