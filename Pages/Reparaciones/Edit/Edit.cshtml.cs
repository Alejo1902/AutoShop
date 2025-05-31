using AutoShopManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Razor;
using AutoShopManager.Models;

namespace AutoShop.Pages.Reparaciones.Edit
{
    public class EditModel : PageModel
    {
        private readonly AutoShopContext _context;
        public EditModel(AutoShopContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Reparacion Reparacion { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Reparaciones == null)
            {
                return NotFound();
            }
            var Reparaciones = await _context.Reparaciones.FirstOrDefaultAsync(m => m.IdReparacion == id);
            if (Reparaciones == null)
            {
                return NotFound();
            }
            Reparaciones = Reparaciones;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Reparacion).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!reparacionExists(Reparacion.IdReparacion))
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
        private bool reparacionExists(int id)
        { 
            return _context.Partes.Any(e => e.IdParte == id);
        }
    }
}