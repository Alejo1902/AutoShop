using AutoShopManager.Data;
using AutoShopManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoShop.Pages.Vehiculos.Eliminar
{
    public class DeleteModel : PageModel
    {
        private readonly AutoShopContext context;
        public DeleteModel(AutoShopContext context)
        {
            context = context;
        }
        [BindProperty]
        public Vehiculo Vehiculos { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || context.Vehiculos == null)
            {
                return NotFound();
            }
            var vehiculo = await context.Vehiculos.FirstOrDefaultAsync(m => m.IdVehiculo == id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            Vehiculos = vehiculo;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || context.Vehiculos == null)
            {
                return NotFound();
            }
            var vehiculo = await context.Vehiculos.FindAsync(id);
            if (vehiculo != null)
            {
                Vehiculos = vehiculo;
                context.Vehiculos.Remove(vehiculo);
                await context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
