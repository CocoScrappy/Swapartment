using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Swapartment.Areas.Identity.Data;
using Swapartment.Models;

namespace Swapartment.Pages_Properties
{
  public class CreateModel : PageModel
  {
    private readonly Swapartment.Areas.Identity.Data.SwapartmentIdentityDbContext _context;

    public CreateModel(Swapartment.Areas.Identity.Data.SwapartmentIdentityDbContext context)
    {
      _context = context;
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
