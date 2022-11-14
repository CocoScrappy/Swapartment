using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Swapartment.Models;

namespace Swapartment.Pages;

public class SearchResultsModel : PageModel
{
  private readonly Swapartment.Areas.Identity.Data.SwapartmentIdentityDbContext _context;

  public SearchResultsModel(Swapartment.Areas.Identity.Data.SwapartmentIdentityDbContext context)
  {
    _context = context;
  }
  public IList<Property> Property { get; set; } = default!;

  public async Task OnGetAsync(string? searchString)
  {
    if (_context.Properties != null)
    {

      Property = await _context.Properties.Include(p => p.Images).ToListAsync();
    }
  }
}
