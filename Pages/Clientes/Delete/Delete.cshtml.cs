using AutoShopManager.Data;
using AutoShopManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AutoShop.Pages.Clientes.Delete
{
    public class DeleteModel : PageModel
    {
        private readonly AutoShopContext context;
        public DeleteModel(AutoShopContext context)
        {
            context = context;
        }
        [BindProperty]
        public Cliente cliente { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || context.Clientes == null)
            {
                return NotFound();
            }
            var Cliente = await context.Clientes.FirstOrDefaultAsync(m => m.IdCliente == id);
            if (Cliente == null)
            {
                return NotFound();
            }
            Cliente = Cliente;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || context.Clientes == null)
            {
                return NotFound();
            }
            var Clientes = await context.Clientes.FindAsync(id);
            if (Clientes != null)
            {
                cliente = cliente;
                context.Clientes.Remove(cliente);
                await context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
