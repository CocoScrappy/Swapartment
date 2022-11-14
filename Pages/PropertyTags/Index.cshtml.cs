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

namespace Swapartment.Pages_PropertyTags
{
  [Authorize(Roles = "ADMIN")]
  public class IndexModel : PageModel
  {
    private readonly Swapartment.Areas.Identity.Data.SwapartmentIdentityDbContext _context;

    public IndexModel(Swapartment.Areas.Identity.Data.SwapartmentIdentityDbContext context)
    {
      _context = context;
    }

    public IList<PropertyTag> PropertyTag { get; set; } = default!;

    public async Task OnGetAsync()
    {
      if (_context.PropertyTags != null)
      {
        PropertyTag = await _context.PropertyTags.OrderBy(p => p.Name).ToListAsync();
      }
    }
  }
}
