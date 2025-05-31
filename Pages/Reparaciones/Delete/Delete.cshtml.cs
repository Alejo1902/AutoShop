using AutoShopManager.Data;
using AutoShopManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AutoShop.Pages.Reparaciones.Delete
{
    public class DeleteModel : PageModel
    {
        private readonly AutoShopContext context;
        public DeleteModel(AutoShopContext context)
        {
            context = context;
        }
        [BindProperty]
        public Reparacion Reparaciones { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || context.Reparaciones == null)
            {
                return NotFound();
            }
            var Reparacion = await context.Reparaciones.FirstOrDefaultAsync(m => m.IdReparacion == id);
            if (Reparaciones == null)
            {
                return NotFound();
            }
            Reparaciones = Reparaciones;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || context.Reparaciones == null)
            {
                return NotFound();
            }
            var Reparaciones = await context.Reparaciones.FindAsync(id);
            if (Reparaciones != null)
            {
                Reparaciones = Reparaciones;
                context.Reparaciones.Remove(Reparaciones);
                await context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
