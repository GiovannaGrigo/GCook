using GCook.Data;
using GCook.ViewModels;
using Microsoft.AspNetCore.Identity;


namespace GCook.Services;

public class UsuarioService : IUsuarioService
{
    private readonly AppDbContext _contexto;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAcessor;
    private readonly IUserStore<IdentityUser> _userStore;
    private readonly IUserEmailStore<IdentityUser> _emailStore;
    private readonly IWebHostEnvironment _hostEnvironment;
    private readonly IEmailSender _emailSender;
    private readonly ILogger<UsuarioService> _logger;

    public UsuarioService(
        AppDbContext contexto,
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
        IHttpContextAccessor httpContextAccessor,
        IUserStore<IdentityUser> userStore,
        IWebHostEnvironment hostEnvironment,
        IEmailSender emailSender,
        ILogger<UsuarioService> logger        
    )
    {
        _contexto = contexto;
        _signInManager = signInManager;
        _userManager = userManager;
        _httpContextAcessor = httpContextAccessor;
        _userStore = userStore;
        _emailStore = (IUserEmailStore<IdentityUser>)_userStore;
        _hostEnvironment = hostEnvironment;
        _emailSender = emailSender;
        _logger = logger;
    }

    public Task<bool> ConfirmarEmail(string userId, string code)
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioVM> GetUsuarioLogado()
    {
        throw new NotImplementedException();
    }

    public Task<SignInResult> LoginUsuario(LoginVM login)
    {
        throw new NotImplementedException();
    }

    public Task LogoffUsuario()
    {
        throw new NotImplementedException();
    }

    public Task<List<string>> RegistrarUsuario(RegistroVM registro)
    {
        throw new NotImplementedException();
    }
}
