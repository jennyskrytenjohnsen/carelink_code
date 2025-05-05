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
    public class RefugeeFamilyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RefugeeFamilyController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /api/refugeesfamilyes from refugee id
        [HttpGet("family/from/{asylumCardId}")]
        public async Task<ActionResult<IEnumerable<Refugee>>> GetFamilyFromRefugee(int asylumCardId)
    {
    // 1. It searches the RefugeeFamilies table in the database and retrieves 
    // the first row where the AsylumCardID matches the value of asylumCardId that you provided.
    var familyEntry = await _context.RefugeeFamilies.FirstOrDefaultAsync(f => f.AsylumCardID == asylumCardId);


    if (familyEntry == null)
    {
        return NotFound($"No family found for refugee with ID {asylumCardId}");
    }

    var familyId = familyEntry.FamilyID;
    // 2. Hent alle AsylumCardId-er i samme familie
    var familyMemberIds = await _context.RefugeeFamilies
        .Where(f => f.FamilyID == familyId)
        .Select(f => f.AsylumCardID)
        .ToListAsync();

    // 3. Hent flyktningene fra Refugees
    var familyRefugees = await _context.Refugees
        .Where(r => familyMemberIds.Contains(r.AsylumCardID))
        .ToListAsync();

    return Ok(familyRefugees);
        }
    }
}
