using System.ComponentModel.DataAnnotations;

namespace AutoShopManager.Models
{
    public class Partes
    {
        [Key]
        public int IdParte { get; set; }

        public string Nombre  { get; set; }

        public string NumeroParte { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public string Proveedor { get; set; }
    }
}
