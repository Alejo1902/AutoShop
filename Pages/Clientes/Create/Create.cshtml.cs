using AutoShopManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoShopManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Razor;

namespace AutoShop.Pages.Clientes.Create
{
    public class CreateModel : PageModel
    {
        private readonly AutoShopContext _context;
        public CreateModel(AutoShopContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public Cliente Clientes { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Vehiculos == null || Clientes == null)
            {
                return Page();
            }
            _context.Clientes.Add(Clientes);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
