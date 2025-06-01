using AutoShop.Models;
using AutoShopManager.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AutoShop.Pages.Autentificacion
{
    public class AuthModel : PageModel
    {
        private readonly ILogger<AuthModel> _logger;
        private readonly AutoShopContext _context;

        public AuthModel(AutoShopContext context, ILogger<AuthModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Users Users { get; set; }

        [BindProperty]
        public bool RememberMe { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            _logger.LogInformation("Intento de inicio de sesión para: {Name}", Users.Name);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ModelState inválido");
                return Page();
            }

            var userInDb = await _context.Users
                .FirstOrDefaultAsync(u => u.Name == Users.Name);

            if (userInDb == null)
            {
                _logger.LogWarning("Usuario no encontrado: {Email}", Users.Name);
                ModelState.AddModelError(string.Empty, "Correo o contraseña inválidos");
                return Page();
            }

            var hasher = new PasswordHasher<Users>();
            var result = hasher.VerifyHashedPassword(userInDb, userInDb.Password, Users.Password);

            if (result == PasswordVerificationResult.Success)
            {
                _logger.LogInformation("Login exitoso para: {Email}", userInDb.Name);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userInDb.Name ?? "Usuario"),
                    new Claim(ClaimTypes.Name, userInDb.Name)
                };

                var identity = new ClaimsIdentity(claims, "AutoShopCookieAuth");
                var principal = new ClaimsPrincipal(identity);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = RememberMe
                };

                await HttpContext.SignInAsync("AutoShopCookieAuth", principal, authProperties);

                return RedirectToPage("/Index");
            }
            else
            {
                _logger.LogWarning("Contraseña incorrecta para: {Email}", userInDb.Name);
                ModelState.AddModelError(string.Empty, "Correo o contraseña inválidos");
                return Page();
            }
        }
    }
}