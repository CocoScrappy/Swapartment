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

namespace Swapartment.Pages_Rentals
{
  [Authorize]
  public class DeleteModel : PageModel
  {
    private readonly Swapartment.Areas.Identity.Data.SwapartmentIdentityDbContext _context;

    public DeleteModel(Swapartment.Areas.Identity.Data.SwapartmentIdentityDbContext context)
    {
      _context = context;
    }

    [BindProperty]
    public Rental Rental { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null || _context.Rentals == null)
      {
        return NotFound();
      }

      var rental = await _context.Rentals.FirstOrDefaultAsync(m => m.Id == id);

      if (rental == null)
      {
        return NotFound();
      }
      else
      {
        Rental = rental;
      }
      return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
      if (id == null || _context.Rentals == null)
      {
        return NotFound();
      }
      var rental = await _context.Rentals.FindAsync(id);

      if (rental != null)
      {
        Rental = rental;
        _context.Rentals.Remove(Rental);
        await _context.SaveChangesAsync();
      }

      return RedirectToPage("./Index");
    }
  }
}
