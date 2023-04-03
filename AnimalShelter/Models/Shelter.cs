using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalShelter.Models
{
  public class Shelter
  {

    public int ShelterId { get; set; }
    public string Name { get; set; }
    public virtual List<Pet> Pets { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public int? PetCount { get; set; }
    public void UpdatePetCount()
    {
        PetCount = Pets?.Count ?? 0;
    }
  }
}