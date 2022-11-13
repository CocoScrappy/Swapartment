using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Swapartment.Areas.Identity.Pages.Manage
{
    public class Choice : PageModel
    {
        private readonly ILogger<Choice> _logger;

        public Choice(ILogger<Choice> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}