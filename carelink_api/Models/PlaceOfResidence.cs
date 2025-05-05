using System.ComponentModel.DataAnnotations.Schema;
namespace carelink_api.Models {
        [Table("place_of_residence")]
    public class PlaceOfResidence{
            public required string StreetName { get; set; }
            public required string StreetNumber { get; set; }
            public required int PostalCode  { get; set; }

             public List<Refugee>? Refugees { get; set; } = new();

    }}
