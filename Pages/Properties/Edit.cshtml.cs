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

namespace Swapartment.Pages_Properties
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
    public Property Property { get; set; } = default!;
    [BindProperty]
    public IList<PropertyTag> Tags { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null || _context.Properties == null)
      {
        return NotFound();
      }
      Tags = await _context.PropertyTags.ToListAsync();

      var property = await _context.Properties.FirstOrDefaultAsync(m => m.Id == id);
      if (property == null)
      {
        return NotFound();
      }
      Property = property;
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

      _context.Attach(Property).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!PropertyExists(Property.Id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      foreach (var item in Tags)
      {
        Console.WriteLine(item.Name);
      }

      return RedirectToPage("./Index");
    }

    private bool PropertyExists(int id)
    {
      return (_context.Properties?.Any(e => e.Id == id)).GetValueOrDefault();
    }
  }
}
