using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Swapartment.Models
{
  [Table("PropertyTags")]
  public class PropertyTag
  {
    public int Id { get; set; }

    [Required]
    [StringLength(25, MinimumLength = 2)]
    public string? Name { get; set; } = default!;

    [Required]
    public string? IconUrl { get; set; } = default!;

    public virtual ICollection<Property>? Property { get; set; } = default!;
  }
}