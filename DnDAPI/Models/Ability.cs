using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnDAPI.Models;

public class Ability
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AbilityId { get; set; }

    [Required(ErrorMessage = "A name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "A description is required")]
    public string Description { get; set; }
    public string? Class { get; set; }
    public int Level { get; set; }
}