using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Swapartment.Areas.Identity.Data;
using Swapartment.Models;

namespace Swapartment.Pages_PropertyTags
{
  public class DetailsModel : PageModel
  {
    private readonly Swapartment.Areas.Identity.Data.SwapartmentIdentityDbContext _context;

    public DetailsModel(Swapartment.Areas.Identity.Data.SwapartmentIdentityDbContext context)
    {
      _context = context;
    }

    public PropertyTag PropertyTag { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null || _context.PropertyTags == null)
      {
        return NotFound();
      }

      var propertytag = await _context.PropertyTags.FirstOrDefaultAsync(m => m.Id == id);
      if (propertytag == null)
      {
        return NotFound();
      }
      else
      {
        PropertyTag = propertytag;
      }
      return Page();
    }
  }
}
