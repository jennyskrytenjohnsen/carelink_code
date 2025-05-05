//This DTO (Data transpher object) is created to when the Refugee class is instansiated, as then we dont need to instanciate the 
// place of residence again

public class CreateRefugeeDTO
{
    public required int AsylumCardID { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public  required string Nationality { get; set; }
    public required DateOnly DOB { get; set; }
    public required DateOnly DateArrivalDK { get; set; }
    public required string RefugeeCoordinatorInitials { get; set; }
    public required string StreetName { get; set; }
    public required string StreetNumber { get; set; }
    public required int PostalCode { get; set; }
    public required int Sex { get; set; }
}
