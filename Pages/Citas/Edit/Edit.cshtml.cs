using AutoShopManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Razor;
using AutoShopManager.Models;

namespace AutoShop.Pages.Citas.Edit
{
    public class EditModel : PageModel
    {
        private readonly AutoShopContext _context;
        public EditModel(AutoShopContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Citas Citas { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Citas == null)
            {
                return NotFound();
            }
            var Citas = await _context.Citas.FirstOrDefaultAsync(m => m.IdCita == id);
            if (Citas == null)
            {
                return NotFound();
            }
            Citas = Citas;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Citas).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitasExists(Citas.IdCita))
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
        private bool CitasExists(int id)
        {
            return _context.Citas.Any(e => e.IdCita == id);
        }
    }
}