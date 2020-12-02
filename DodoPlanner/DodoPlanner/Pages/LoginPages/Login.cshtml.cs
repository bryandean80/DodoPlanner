using DodoPlanner.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using DodoPlanner.Services;


namespace DodoPlanner.Pages.LoginPages
{
    public class LoginModel : PageModel
    {
        private readonly IConfiguration configuration;
        public SqlTdListService tdlistservice;
        public LoginModel(IConfiguration configuration, SqlTdListService tdListService)
        {
            this.configuration = configuration;
            this.tdlistservice = tdListService;
        }
        
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }
        public string Message { get; set; }
        public async Task<IActionResult> OnPost()
        {

            if (tdlistservice.login(UserName, Password))
            {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, UserName)
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToPage("/Index");
            }
            Message = "Invalid attempt";
            return Page();
        }
    }
}
