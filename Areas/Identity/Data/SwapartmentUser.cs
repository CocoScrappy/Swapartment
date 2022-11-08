using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Swapartment.Areas.Identity.Data
{
  public class SwapartmentUser : IdentityUser
  {
    //Nullable in case registration is in 2 forms
    public string? Bio { get; set; } = default!;

    public string? FirstName { get; set; } = default!;

    public string? LastName { get; set; } = default!;

    public string? ImageUrl { get; set; } = default!;
  }
}