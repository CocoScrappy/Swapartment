using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swapartment.Areas.Identity.Data;
using Swapartment.Models;

namespace Swapartment.Pages_PropertyImages
{
  [Authorize]
  public class EditModel : PageModel
  {
    private readonly Swapartment.Areas.Identity.Data.SwapartmentIdentityDbContext _context;

    public EditModel(Swapartment.Areas.Identity.Data.SwapartmentIdentityDbContext context)
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
      PropertyImage = propertyimage;
      return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      _context.Attach(PropertyImage).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!PropertyImageExists(PropertyImage.Id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return RedirectToPage("./Index");
    }

    private bool PropertyImageExists(int id)
    {
      return (_context.PropertyImages?.Any(e => e.Id == id)).GetValueOrDefault();
    }
  }
}
