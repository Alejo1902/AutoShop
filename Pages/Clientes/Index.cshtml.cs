using AutoShopManager.Data;
using AutoShopManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AutoShop.Pages.Clientes

{
    public class IndexModel : PageModel
    {
        private readonly AutoShopManager.Data.AutoShopContext _context;

        public IndexModel(AutoShopContext context)
        {
            _context = context;
        }
        public IList<Cliente> Clientes { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Clientes != null)
            {
                Clientes = await _context.Clientes.ToListAsync();

            }
        }
    }
}
