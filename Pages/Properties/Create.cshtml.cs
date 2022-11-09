using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Swapartment.Areas.Identity.Data;
using Swapartment.Models;

namespace Swapartment.Pages_Properties
{
  [Authorize]
  public class CreateModel : PageModel
  {
    private readonly SwapartmentIdentityDbContext _context;
    private readonly UserManager<SwapartmentUser> _userManager;

    public CreateModel(SwapartmentIdentityDbContext context, UserManager<SwapartmentUser> userManager)
    {
      _context = context;
      _userManager = userManager;
    }

    public IActionResult OnGet()
    {

      return Page();
    }

    [BindProperty]
    public Property Property { get; set; } = default!;


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
      var currentUser = await _userManager.GetUserAsync(User);
      var role = await _userManager.GetRolesAsync(currentUser);
      Property.SwapartmentUser = currentUser;
      if (!ModelState.IsValid || _context.Properties == null || Property == null)
      {
        return Page();
      }



      _context.Properties.Add(Property);
      await _context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}
