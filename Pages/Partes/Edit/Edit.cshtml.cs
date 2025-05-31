using AutoShopManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Razor;
using AutoShopManager.Models;

namespace AutoShop.Pages.Partes.Edit
{
    public class EditModel : PageModel
    {
        private readonly AutoShopContext _context;
        public EditModel(AutoShopContext context)
        {
            _context = context;
        }
        [BindProperty]
        public partes partes { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Partes == null)
            {
                return NotFound();
            }
            var partes = await _context.Partes.FirstOrDefaultAsync(m => m.IdParte == id);
            if (partes == null)
            {
                return NotFound();
            }
            partes = partes;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Partes).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!partesExists(Partes.IdPartes))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Index");
        }
        private bool PartesExists(int id)
        {
            return (_context.Partes.Any(e => e.IdParte == id)).GetValueOrDefault();
        }
    }
}