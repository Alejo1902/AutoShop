using AutoShopManager.Data;
using AutoShopManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AutoShop.Pages.Reparaciones

{
    public class IndexModel : PageModel
    {
        private readonly AutoShopManager.Data.AutoShopContext _context;

        public IndexModel(AutoShopContext context)
        {
            _context = context;
        }
        public IList<Reparacion> Reparaciones { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Reparaciones != null)
            {
                Reparaciones = await _context.Reparaciones.ToListAsync();

            }
        }
    }
}
