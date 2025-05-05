
// How attributes and functions are understood in the Entity Framework (EF)
using System.ComponentModel.DataAnnotations.Schema; // More complex comparet to the one without schema
using System.ComponentModel.DataAnnotations;
namespace carelink_api.Models {

    [Table("refugee")]
    public class Refugee{
        [Key]
        public required int AsylumCardID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required  string Nationality { get; set; }
        
        public required  DateOnly DOB { get; set; }
        public required  DateOnly DateArrivalDK { get; set; }

        public required string RefugeeCoordinatorInitials { get; set; }

        public required  string StreetName { get; set; }
        public required string StreetNumber { get; set; }
        public required  int PostalCode { get; set; }
        public required int Sex { get; set; }

        [ForeignKey("StreetName,StreetNumber,PostalCode")]
        public PlaceOfResidence? PlaceOfResidence { get; set; }

    }
    }