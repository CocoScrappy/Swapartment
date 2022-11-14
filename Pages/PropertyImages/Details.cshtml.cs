using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Swapartment.Areas.Identity.Data;
using Swapartment.Models;

namespace Swapartment.Pages_PropertyImages
{
  [Authorize]
  public class DetailsModel : PageModel
  {
    private readonly Swapartment.Areas.Identity.Data.SwapartmentIdentityDbContext _context;

    public DetailsModel(Swapartment.Areas.Identity.Data.SwapartmentIdentityDbContext context)
    {
      _context = context;
    }

    public PropertyImage PropertyImage { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null || _context.PropertyImages == null)
      {
        return NotFound();
      }

      var propertyimage = await _context.PropertyImages.FirstOrDefaultAsync(m => m.Id == id);
      if (propertyimage == null)
      {
        return NotFound();
      }
      else
      {
        PropertyImage = propertyimage;
      }
      return Page();
    }
  }
}
