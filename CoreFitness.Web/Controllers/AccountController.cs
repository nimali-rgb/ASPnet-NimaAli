using CoreFitness.Web.Areas.Identity.Data;
using CoreFitness.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;


namespace CoreFitness.Web.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;      
    private readonly SignInManager<ApplicationUser> _signInManager;  

    public AccountController(UserManager<ApplicationUser> userManager,
                             SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    public IActionResult Index()
    {
        return View();
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

        if (model.Email is null || model.Password is null)
        {
            ModelState.AddModelError("", "Email och lösenord krävs.");
            return View(model);
        }

        var user = new ApplicationUser { UserName = model.Email, Email = model.Email }; 
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

        if (user is null)
            return NotFound();

        await _userManager.DeleteAsync(user);
        await _signInManager.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }

    // UPLOAD PROFILE IMAGE
    [Authorize]
    [HttpGet]
    public IActionResult UploadProfileImage()
    {
        return View();
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> UploadProfileImage(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            TempData["Error"] = "Ingen bild vald.";
            return RedirectToAction("UploadProfileImage");
        }

        // Tillåtna filtyper
        var allowed = new[] { ".jpg", ".jpeg", ".png" };
        var ext = Path.GetExtension(file.FileName).ToLower();

        if (!allowed.Contains(ext))
        {
            TempData["Error"] = "Endast JPG och PNG är tillåtna.";
            return RedirectToAction("UploadProfileImage");
        }

        // Hämta användare
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            TempData["Error"] = "Kunde inte hitta användaren.";
            return RedirectToAction("Index", "MyPage");
        }

        // Skapa filnamn
        var fileName = $"{userId}{ext}";
        var savePath = Path.Combine("wwwroot/images/profile", fileName);

        // Spara filen
        using (var stream = new FileStream(savePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        // Uppdatera användaren
        user.ProfileImageUrl = $"/images/profile/{fileName}";
        await _userManager.UpdateAsync(user);

        TempData["Success"] = "Profilbild uppdaterad!";
        return RedirectToAction("Index", "MyPage");
    }

}
