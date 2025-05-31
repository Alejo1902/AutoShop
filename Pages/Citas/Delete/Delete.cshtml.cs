using AutoShopManager.Data;
using AutoShopManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AutoShop.Pages.Citas.Delete
{
    public class DeleteModel : PageModel
    {
        private readonly AutoShopContext context;
        public DeleteModel(AutoShopContext context)
        {
            context = context;
        }
        [BindProperty]
        public Citas Citas { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || context.Citas == null)
            {
                return NotFound();
            }
            var Citas = await context.Citas.FirstOrDefaultAsync(m => m.IdCita == id);
            if (Citas == null)
            {
                return NotFound();
            }
            Citas = Citas;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || context.Citas == null)
            {
                return NotFound();
            }
            var Citas = await context.Citas.FindAsync(id);
            if (Citas != null)
            {
                Citas = Citas;
                context.Reparaciones.Remove(Citas);
                await context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
