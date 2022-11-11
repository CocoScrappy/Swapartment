using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using Swapartment.Helpers;
using System.Configuration;
using Microsoft.Extensions.Options;
using Azure.Identity;
using Microsoft.AspNetCore.Authorization;
using Swapartment.Areas.Identity.Data;

namespace Swapartment.Pages;


public class UploadModel : PageModel
{
    private BlobContainerClient _containerClient;

    [BindProperty]
    public IFormFile Upload { get; set; }
    public IFormFileCollection Uploads { get; set; }


    public UploadModel(IOptions<AzureStorageConfig> config, IWebHostEnvironment env)
      //public UploadModel(IOptions config, IWebHostEnvironment env)
    {
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


    public async Task<IActionResult> OnPostAsync()
    {

        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            // Create the container if it does not exist.
            await _containerClient.CreateIfNotExistsAsync();

            // Upload the file to the container
            await _containerClient.UploadBlobAsync(Upload.FileName, Upload.OpenReadStream());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return Page();

    }
}
