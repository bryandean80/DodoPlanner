using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DodoPlanner.Models;
using DodoPlanner.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DodoPlanner.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger
            )
        {
            _logger = logger;
        }
    }
}
