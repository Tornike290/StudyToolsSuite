using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudyToolsSuite.Models;
using System.Threading.Tasks;

public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // GET: /Account/Register
    public IActionResult Register()
    {
        return View();
    }

    // POST: /Account/Register
    [HttpPost]
    public async Task<IActionResult> Register(string firstName, string fullName, string email, string password, string retypedPassword)
    {
        if (password != retypedPassword)
        {
            ModelState.AddModelError("Password", "Passwords do not match.");
            return View();
        }

        var user = new ApplicationUser
        {
            FirstName = firstName,
            FullName = fullName,
            UserName = email,
            Email = email
        };

        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            // Automatically sign the user in after registration
            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }

        // If registration failed, display the errors
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }

        return View();
    }
}