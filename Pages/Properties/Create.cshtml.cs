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
using Azure.Storage.Blobs;
using Swapartment.Helpers;
using Microsoft.Extensions.Options;
using Azure.Identity;

namespace Swapartment.Pages_Properties
{
  [Authorize]
  public class CreateModel : PageModel
  {
    private readonly SwapartmentIdentityDbContext _context;
    private readonly UserManager<SwapartmentUser> _userManager;

    [BindProperty]
    public Property Property { get; set; } = default!;
    public PropertyImage PropertyImage { get; set; } = default!;

    private BlobContainerClient _containerClient;
    [BindProperty]
    public IFormFile Upload { get; set; }
    [BindProperty]
    public IFormFileCollection Uploads { get; set; }

    public CreateModel(SwapartmentIdentityDbContext context, UserManager<SwapartmentUser> userManager, IOptions<AzureStorageConfig> config, IWebHostEnvironment env)
    {
      _context = context;
      _userManager = userManager;

      if (env.IsDevelopment())
      {
        _containerClient = new BlobContainerClient(config.Value.BlobAccountName, config.Value.BlobContainerName);
      }
      else
      {
        string containerEndpoint = string.Format("https://{0}.blob.core.windows.net/{1}",
          config.Value.BlobAccountName,
          config.Value.BlobContainerName);
        _containerClient = new BlobContainerClient(new Uri(containerEndpoint), new DefaultAzureCredential());
      }

    }

    public IActionResult OnGet()
    {
      return Page();
    }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
      var currentUser = await _userManager.GetUserAsync(User);

      Property.SwapartmentUser = currentUser;
      if (!ModelState.IsValid || _context.Properties == null || Property == null || Uploads.Count == 0)
      {
        return Page();
      }

      try
      {
        // Create the container if it does not exist.
        await _containerClient.CreateIfNotExistsAsync();

        for (int i = 0; i < Uploads.Count; i++)
        {

        }


        // create uuid for filename
        string uuid = Guid.NewGuid().ToString();
        await _containerClient.UploadBlobAsync(uuid, Upload.OpenReadStream());
        PropertyImage.ImageUrl = uuid;
        Property.Images.Add(PropertyImage);
        // Upload the file to the container

      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
<<<<<<< HEAD
=======

>>>>>>> main

      _context.Properties.Add(Property);
      await _context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}
