using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class SheltersController : ControllerBase
  {
    private readonly AnimalShelterContext _db;

    public SheltersController(AnimalShelterContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Shelter>>> Get(string name, string search)
    {
      IQueryable<Shelter> query = _db.Shelters.Include(shelter => shelter.Pets).AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      if (search == "random")
      {
        Random random = new Random();
        int randomId = random.Next(1, (1 + query.Count()));
        query = query.Where(entry => entry.ShelterId == randomId);
      }

      var shelters = await query.ToListAsync();

      foreach (var shelter in shelters)
      {
        shelter.PetCount = shelter.Pets?.Count() ?? 0;
      }

      if (search == "popular")
      {
        shelters = shelters.OrderByDescending(shelters => shelters.PetCount).ToList();
      }

      return shelters;
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Shelter>> GetShelter(int id)
    {
      Shelter shelter = await _db.Shelters.Include(d => d.Pets).FirstOrDefaultAsync(d => d.ShelterId == id);

      if (shelter == null)
      {
        return NotFound();
      }

      return shelter;
    }

    [HttpPost]
    public async Task<ActionResult<Shelter>> Post(Shelter shelter)
    {
      _db.Shelters.Add(shelter);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetShelter), new { id = shelter.ShelterId }, shelter);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Shelter shelter)
    {
      if (id != shelter.ShelterId)
      {
        return BadRequest();
      }

      _db.Shelters.Update(shelter);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ShelterExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    private bool ShelterExists(int id)
    {
      return _db.Shelters.Any(e => e.ShelterId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShelter(int id)
    {
      Shelter shelter = await _db.Shelters.FindAsync(id);
      if (shelter == null)
      {
        return NotFound();
      }

      _db.Shelters.Remove(shelter);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}