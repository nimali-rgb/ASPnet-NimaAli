using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CoreFitness.Web.Models;

namespace CoreFitness.Web.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(UserManager<IdentityUser> userManager,
                             SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // REGISTER GET
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    // REGISTER POST
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        // Null-säkerhet
        if (model.Email is null || model.Password is null)
        {
            ModelState.AddModelError("", "Email och lösenord krävs.");
            return View(model);
        }

        var user = new IdentityUser { UserName = model.Email, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }

        foreach (var error in result.Errors)
            ModelState.AddModelError("", error.Description);

        return View(model);
    }

    // LOGIN GET
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    // LOGIN POST
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        // Null-säkerhet
        if (model.Email is null || model.Password is null)
        {
            ModelState.AddModelError("", "Email och lösenord krävs.");
            return View(model);
        }

        var result = await _signInManager.PasswordSignInAsync(
            model.Email, model.Password, model.RememberMe, false);

        if (result.Succeeded)
            return RedirectToAction("Index", "Home");

        ModelState.AddModelError("", "Invalid login attempt");
        return View(model);
    }

    // LOGOUT
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    // MY ACCOUNT
    [HttpGet]
    public async Task<IActionResult> MyAccount()
    {
        var user = await _userManager.GetUserAsync(User);

        if (user is null)
            return RedirectToAction("Login");

        return View(user);
    }

    // DELETE ACCOUNT
    [HttpPost]
    public async Task<IActionResult> DeleteAccount()
    {
        var user = await _userManager.GetUserAsync(User);

        // Null-säkerhet
        if (user is null)
            return NotFound();

        await _userManager.DeleteAsync(user);
        await _signInManager.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }
}
