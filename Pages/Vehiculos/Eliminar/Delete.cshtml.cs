using AutoShopManager.Data;
using AutoShopManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
            var Vehiculo = await context.Vehiculos.FirstOrDefaultAsync(m => m.IdVehiculo == id);
            if (Vehiculo == null)
            {
                return NotFound();
            }
            Vehiculos = Vehiculo;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || context.Vehiculos == null)
            {
                return NotFound();
            }
            var Vehiculo = await context.Vehiculos.FindAsync(id);
            if (Vehiculo != null)
            {
                Vehiculos = Vehiculo;
                context.Vehiculos.Remove(Vehiculo);
                await context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
