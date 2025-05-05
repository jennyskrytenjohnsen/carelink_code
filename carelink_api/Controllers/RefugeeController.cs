using Microsoft.AspNetCore.Mvc;
using carelink_api.Data;  //Makes us able to easily use the data file
using carelink_api.Models; //Makes us able to easily use the model file
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore; //Lets you handle databases in C# without the need for writing SQL code
using System.Dynamic;



namespace carelink_api.Controllers //Says, this controller.cs file belongs in the Controllers folder
{
    [ApiController] //Explains to ASP.NET, this is an api controller
    [Route("api/[controller]")] //Defines the URL path for the API. Controllor is automatically turned to Refugee because the class is called RefugeeController
    public class RefugeeController : ControllerBase // Instanciate a new controller class, which is inheritings functions etc from contorller base
    {
        private readonly AppDbContext _context;

        public RefugeeController(AppDbContext context)
        {
            _context = context; //is databindingsobjektet i EF Core (instance of the the appDbContet.cs class)
        }

        // GET: /api/refugees
        [HttpGet] //Using for collection database information usign the HPPT get
        //This API returns all the refugess in the Refugee table

    public async Task<ActionResult<IEnumerable<Refugee>>> GetAll()
    {
       return await _context.Refugees.ToListAsync();
        }
   
    //Adding a new refugee, the POST is used for adding
    [HttpPost]
    public async Task<ActionResult<Refugee>> CreateRefugee(CreateRefugeeDTO dto)
    
    {
        var refugee = new Refugee

        {
        AsylumCardID = dto.AsylumCardID,
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        Nationality = dto.Nationality,
        DOB = dto.DOB,
        DateArrivalDK = dto.DateArrivalDK,
        RefugeeCoordinatorInitials = dto.RefugeeCoordinatorInitials,
        StreetName = dto.StreetName,
        StreetNumber = dto.StreetNumber,
        PostalCode = dto.PostalCode,
        Sex = dto.Sex
        };

        _context.Refugees.Add(refugee); //_context is AppDbContext (connection to database)
        await _context.SaveChangesAsync(); //Saves changes in the database

        return CreatedAtAction (nameof(GetById), new { id = refugee.AsylumCardID}, refugee);

    }

    [HttpGet("{id}")] //Collects Refugree from id

    public async Task<ActionResult<Refugee>> GetById(int id)

    {
        var refugee = await _context.Refugees.FindAsync(id);

        if (refugee == null)

        {
            return NotFound($"No refugee found with ID {id}");

        }
    
    return Ok(refugee); // Says everything is find, here it the HTTP 200 ok responds

}}}

