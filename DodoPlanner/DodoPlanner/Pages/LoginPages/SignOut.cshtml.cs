using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DodoPlanner.Pages.LoginPages
{
    public class SignOutModel : PageModel
    {
        public IActionResult OnPost()
        {
            Response.Cookies.Delete("UserCookie");
            Response.Cookies.Delete("username");
            return RedirectToPage("/Index");
        }
    }
}
