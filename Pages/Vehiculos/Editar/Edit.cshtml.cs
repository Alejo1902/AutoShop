using AutoShopManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Razor;

namespace AutoShop.Pages.Vehiculos.Editar
{
    public class EditModel : PageModel
    {
        private readonly AutoShopContext _context;
        public EditModel(AutoShopContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Vehiculos Vehiculo { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vehiculos == null)
            {
                return NotFound();
            }
            var vehiculo = await _context.Vehiculos.FirstOrDefaultAsync(m => m.IdVehiculo == id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            Vehiculo = vehiculo;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Vehiculo).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculosExists(Vehiculo.IdVehiculo))
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
        private bool VehiculosExists(int id)
        {
            return (_context.Vehiculos.Any(e => e.IdVehiculo == id))
        }
    }
}