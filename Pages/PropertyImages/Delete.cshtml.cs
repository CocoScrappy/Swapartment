using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Swapartment.Areas.Identity.Data;
using Swapartment.Models;

namespace Swapartment.Pages_PropertyImages
{
  public class DeleteModel : PageModel
  {
    private readonly Swapartment.Areas.Identity.Data.SwapartmentIdentityDbContext _context;

    public DeleteModel(Swapartment.Areas.Identity.Data.SwapartmentIdentityDbContext context)
    {
      _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
      if (id == null || _context.PropertyImages == null)
      {
        return NotFound();
      }
      var propertyimage = await _context.PropertyImages.FindAsync(id);

      if (propertyimage != null)
      {
        PropertyImage = propertyimage;
        _context.PropertyImages.Remove(PropertyImage);
        await _context.SaveChangesAsync();
      }

      return RedirectToPage("./Index");
    }
  }
}
