using AutoShop.Models;
using AutoShopManager.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AutoShop.Pages.Autentificacion
{
    public class RegisterModel : PageModel
    {
        private readonly AutoShopContext _context;

        public RegisterModel(AutoShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Users User { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // Verifica si ya existe un usuario con el mismo correo
            var exists = await _context.Users.AnyAsync(u => u.Name == User.Name);
            if (exists)
            {
                ModelState.AddModelError(string.Empty, "Ya existe una cuenta con este Nombre.");
                return Page();
            }

            // Hashea la contraseña antes de guardar
            var hasher = new PasswordHasher<Users>();
            User.Password = hasher.HashPassword(User, User.Password);

            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("Login");
        }
    }
}