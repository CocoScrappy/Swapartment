using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Swapartment.Models
{
  [Table("PropertyImages")]
  public class PropertyImage
  {
    public int Id { get; set; }

    [Required]
    public string ImageUrl { get; set; } = default!;

  }
}