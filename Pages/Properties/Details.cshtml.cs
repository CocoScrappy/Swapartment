using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Swapartment.Areas.Identity.Data;
using Swapartment.Models;

namespace Swapartment.Pages_Properties
{
  public class DetailsModel : PageModel
  {
    private readonly Swapartment.Areas.Identity.Data.SwapartmentIdentityDbContext _context;

    public DetailsModel(Swapartment.Areas.Identity.Data.SwapartmentIdentityDbContext context)
    {
      _context = context;
    }

    public Property Property { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null || _context.Properties == null)
      {
        return NotFound();
      }

      var property = await _context.Properties.Include(p => p.SwapartmentUser).FirstOrDefaultAsync(m => m.Id == id);
      if (property == null)
      {
        return NotFound();
      }
      else
      {
        Property = property;
      }
      return Page();
    }
  }
}
