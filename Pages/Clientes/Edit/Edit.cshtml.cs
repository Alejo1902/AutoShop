using AutoShopManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Razor;
using AutoShopManager.Models;

namespace AutoShop.Pages.Clientes.Edit
{
    public class EditModel : PageModel
    {
        private readonly AutoShopContext _context;
        public EditModel(AutoShopContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Vehiculo Vehiculo { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.FirstOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }
            cliente = cliente;
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
                if (!ClientesExists(Clientes.IdCliente))
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
        private bool ClientesExists(int id)
        {
            return (_context.Clientes.Any(e => e.IdCliente == id)).GetValueOrDefault();
        }
    }
}