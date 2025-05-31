using AutoShopManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoShopManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Razor;

namespace AutoShop.Pages.Citas.Create
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
        public Citas Citas{ get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Citas == null || Citas == null)
            {
                return Page();
            }
            _context.Citas.Add(Citas);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
