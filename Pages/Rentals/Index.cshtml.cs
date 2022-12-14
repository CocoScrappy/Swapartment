using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Swapartment.Areas.Identity.Data;
using Swapartment.Models;

namespace Swapartment.Pages_Rentals
{
  [Authorize]
  public class IndexModel : PageModel
  {
    private readonly Swapartment.Areas.Identity.Data.SwapartmentIdentityDbContext _context;
    private readonly UserManager<SwapartmentUser> _userManager;

    public IndexModel(Swapartment.Areas.Identity.Data.SwapartmentIdentityDbContext context, UserManager<SwapartmentUser> userManager)
    {
      _context = context;
      _userManager = userManager;
    }

    public IList<Rental> Rental { get; set; } = default!;

    public async Task OnGetAsync()
    {
      if (_context.Rentals != null)
      {
        var currentUser = await _userManager.GetUserAsync(User);
        Rental = await _context.Rentals.Include(r => r.Property).Where(r => r.Renter == currentUser).ToListAsync();
      }
    }
  }
}
