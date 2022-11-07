using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Swapartment.Models
{
  public class PropertyImage
  {
    public int Id { get; set; }

    [Required]
    public string ImageUrl { get; set; } = default!;

    [Required]
    public virtual Property Property { get; set; } = default!;
  }
}