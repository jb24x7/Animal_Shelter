using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class PetsController : ControllerBase
  {
    private readonly AnimalShelterContext _db;

    public PetsController(AnimalShelterContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pet>>> Get(string name)
    {
      IQueryable<Pet> query = _db.Pets.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pet>> GetPet(int id)
    {
      Pet pet = await _db.Pets.FindAsync(id);

      if (pet == null)
      {
        return NotFound();
      }

      return pet;
    }

    [HttpPost]
    public async Task<ActionResult<Pet>> Post(Pet pet)
    {
      _db.Pets.Add(pet);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetPet), new { id = pet.PetId }, pet);
    }


    [HttpPut("{id}")]
public async Task<IActionResult> Put(int id, Pet pet)
{
    if (id != pet.PetId)
    {
        return BadRequest();
    }

    var existingPet = await _db.Pets.FindAsync(id);

    if (existingPet == null)
    {
        return NotFound();
    }

    if (existingPet.user_name != pet.user_name)
    {
        return BadRequest("User name does not match.");
    }

    existingPet.Name = pet.Name;

    try
    {
        await _db.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!PetExists(id))
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

private bool PetExists(int id)
{
    return _db.Pets.Any(e => e.PetId == id);
}

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePet(int id)
    {
      Pet pet = await _db.Pets.FindAsync(id);
      if (pet == null)
      {
        return NotFound();
      }

      _db.Pets.Remove(pet);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}