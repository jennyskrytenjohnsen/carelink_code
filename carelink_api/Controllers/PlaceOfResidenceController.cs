using Microsoft.AspNetCore.Mvc;
using carelink_api.Data;
using carelink_api.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace carelink_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaceOfResidenceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlaceOfResidenceController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /api/placeOfResidence 
        [HttpGet]
    public async Task<ActionResult<IEnumerable<PlaceOfResidence>>> GetAll()
    {
        return await _context.PlaceOfResidences.ToListAsync();
        }

        [HttpGet("refugees/from/{streetName}/{streetNumber}/{postalCode}")]
        public async Task<ActionResult<IEnumerable<Refugee>>> GetRefugeeFromPlaceOfResidence(string streetName, string streetNumber, int postalCode )

    { //Find refugee with the concrete adress in the refugee table

    var refugees = await _context.Refugees
        .Where(r =>
            r.StreetName == streetName &&
            r.StreetNumber == streetNumber &&
            r.PostalCode == postalCode)
        .ToListAsync();

    if (!refugees.Any())
    {
        return NotFound("No refugees found at that address.");
    }

    return Ok(refugees);
}

}
        
}
