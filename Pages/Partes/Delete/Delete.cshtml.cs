using AutoShopManager.Data;
using AutoShopManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AutoShop.Pages.Partes.Delete
{
    public class DeleteModel : PageModel
    {
        private readonly AutoShopContext context;
        public DeleteModel(AutoShopContext context)
        {
            context = context;
        }
        [BindProperty]
        public partes partes { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || context.Partes == null)
            {
                return NotFound();
            }
            var Partes = await context.Partes.FirstOrDefaultAsync(m => m.IdParte == id);
            if (Partes == null)
            {
                return NotFound();
            }
            Partes = Partes;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || context.Partes == null)
            {
                return NotFound();
            }
            var Partes = await context.Partes.FindAsync(id);
            if (Partes != null)
            {
                Partes = Partes;
                context.Partes.Remove(Partes);
                await context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
