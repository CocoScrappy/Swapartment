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
using Microsoft.EntityFrameworkCore;
using Azure.Storage.Blobs.Models;

namespace Swapartment.Pages_Properties
{
  [Authorize]
  public class CreateModel : PageModel
  {
    private readonly SwapartmentIdentityDbContext _context;
    private readonly UserManager<SwapartmentUser> _userManager;

    [BindProperty]
    public Property Property { get; set; } = default!;

    private BlobContainerClient _containerClient;

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


    public async Task<IActionResult> OnPostAsync()
    {
      var currentUser = await _userManager.GetUserAsync(User);

      Property.SwapartmentUser = currentUser;
      if (!ModelState.IsValid || _context.Properties == null || Property == null || Uploads.Count < 5)
      {
        return Page();
      }


      try
      {
        // Create the container if it does not exist.
        await _containerClient.CreateIfNotExistsAsync();
        _context.Properties.Add(Property);
        await _context.SaveChangesAsync();

        // instantiate Property.Images
        var propImgList = new List<PropertyImage>();

        string containerEndpoint = _containerClient.Uri.AbsoluteUri;

        for (int i = 0; i < Uploads.Count; i++)
        {
          string uuid = Guid.NewGuid().ToString();
          propImgList.Add(new PropertyImage());
          propImgList.ElementAt(i).ImageUrl = containerEndpoint + "/" + uuid;

          Property.Images = propImgList;
          // Upload the file to the container
          var cont_type = Uploads[i].ContentType;

          Stream stream = Uploads[i].OpenReadStream();
          BlobClient blobClient = _containerClient.GetBlobClient(uuid);
          await blobClient.UploadAsync(stream, true);
          var res = blobClient.SetHttpHeaders(new BlobHttpHeaders() { ContentType = Uploads[i].ContentType });

          if (!res.GetRawResponse().Status.ToString().StartsWith("2"))
          {
            throw new Exception("Upload failed");
          }
          _context.Attach(Property).State = EntityState.Modified;
          await _context.SaveChangesAsync();
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }

      return RedirectToPage("./Index");
    }
  }
}
