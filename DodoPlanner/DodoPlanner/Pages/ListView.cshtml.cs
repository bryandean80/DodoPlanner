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
    public class ListViewModel : PageModel
    {
        private readonly ILogger<ListViewModel> _logger;

        public ListViewModel(ILogger<ListViewModel> logger, JsonFileTdListService service)
        {
            _logger = logger;
        }
    }
}
