using System.ComponentModel.DataAnnotations;

namespace dojoleague.Models {
    public class Dojo : BaseEntity{

        [Key]
        public long Id {get; set;}

        [Required(ErrorMessage="We have to know where it is")]
        public string Location {get; set;}

        [Required(ErrorMessage="Provide additional info on the Dojo")]
        public string Description {get; set;}


    }
}