using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoShopManager.Models
{
    public class Reparacion
    {
        [Key]
        public int IdReparacion { get; set; }

        public string Descripcion { get; set; }

        [ForeignKey("Vehiculo")]
        public int IdVehiculo { get; set; }
        public Vehiculo Vehiculo { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public decimal CostoEstimado { get; set; }
    }
}
