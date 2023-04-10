using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalShelter.Models
{
  public class Pet
  {

    public int PetId { get; set; }
    [ForeignKey("Shelter")]
    public int ShelterId { get; set; }
    
    [StringLength(120)]
    public string Title { get; set; }
    public string Name { get; set; }
    [Required]
    public string user_name { get; set; }
  }
}

