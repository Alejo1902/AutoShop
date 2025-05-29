using AutoShopManager.Data;
using AutoShopManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AutoShop.Pages.Vehiculos
{
    public class IndexModel : PageModel
    {
        private readonly AutoShopManager.Data.AutoShopContext _context;

        public IndexModel(AutoShopContext context)
        {
            _context = context;
        }
        public IList<Vehiculo> Vehiculos { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Vehiculos != null)
            {
                Vehiculos = await _context.Vehiculos.ToListAsync();

            }
        }
    }
}
