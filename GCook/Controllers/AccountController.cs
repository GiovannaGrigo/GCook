
using GCook.Services;
using GCook.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GCook.Controllers;

public class AccountController : Controller
{
    private ILogger<AccountController> _logger;
    private readonly IUsuarioService _usuarioService;

    public AccountController(ILogger<AccountController> logger, IUsuarioService usuarioService)
    {
        _logger = logger;
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public IActionResult Login(string returnUrl)
    {
        LoginVM login = new()
        {
            UrlRetorno = returnUrl ?? Url.Content("~/")
        };
        return View(login);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginVM login)
    {
        if (ModelState.IsValid)
        {
            var result = await _usuarioService.LoginUsuario(login);
            if (result.Succeeded)
                return LocalRedirect(login.UrlRetorno);
            if (result.IsLockedOut)
                return RedirectToAction("Lockout");
            if (result.IsNotAllowed)
                ModelState.AddModelError(string.Empty, "Sua conta não está confirmada, verifique seu email!!");
            else
                ModelState.AddModelError(string.Empty, "Usuário e/ou Senha Inválidos!!!");
        }
        return View(login);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _usuarioService.LogoffUsuario();
        return RedirectToAction("Index", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
