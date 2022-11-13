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


    public CreateModel(SwapartmentIdentityDbContext context, UserManager<SwapartmentUser> userManager)
    {
      _context = context;
      _userManager = userManager;
    }

    [BindProperty]
    public Rental Rental { get; set; }

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
      //Get property ID and Current User Id Into Rental.
      Rental = new Rental();
      Rental.Property = property;


      return Page();
    }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync(int id)
    {
      if (!ModelState.IsValid || _context.Rentals == null || Rental == null)
      {
        return Page();
      }

      /* Stripe Stuff Would Go Here */

      var property = await _context.Properties.FirstOrDefaultAsync(m => m.Id == id);
      if (property == null)
      {
        return NotFound();
      }
      //Get property ID and Current User Id Into Rental.
      Rental.Property = property;

      Rental.Renter = await _userManager.GetUserAsync(User);
      _context.Rentals.Add(Rental);
      await _context.SaveChangesAsync();

      return RedirectToPage("./Details/", null, new { id = Rental.Id });
    }
  }
}
