using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swapartment.Areas.Identity.Data;
using Swapartment.Models;

namespace Swapartment.Pages_Rentals
{
  public class CreateModel : PageModel
  {
    private readonly SwapartmentIdentityDbContext _context;
    private readonly UserManager<SwapartmentUser> _userManager;

    public Property? Property { get; set; }
    public CreateModel(SwapartmentIdentityDbContext context, UserManager<SwapartmentUser> userManager)
    {
      _context = context;
      _userManager = userManager;
    }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      //requires a Property Id passed in the URL
      if (id == null || _context.Properties == null)
      {
        return NotFound();
      }

      var property = await _context.Properties.FirstOrDefaultAsync(m => m.Id == id);
      if (property == null)
      {
        return NotFound();
      }
      Property = property;
      return Page();
    }

    [BindProperty]
    public Rental Rental { get; set; } = default!;


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid || _context.Rentals == null || Rental == null)
      {
        return Page();
      }

      /* Stripe Stuff Would Go Here */

      //Get property ID and Current User Id Into Rental.
      Rental.Property = Property;
      Rental.Renter = await _userManager.GetUserAsync(User);
      _context.Rentals.Add(Rental);
      await _context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}
