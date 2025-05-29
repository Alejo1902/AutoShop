using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoShopManager.Models
{
    public class Citas
    {
        [Key]
        public int IdCita { get; set; }

        [ForeignKey("Vehiculo")]
        public int IdVehiculo { get; set; }
        public Vehiculo Vehiculo { get; set; }

        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }

        public DateTime Fecha { get; set; }

        public TimeSpan Hora { get; set; }

        public string DescripcionServicio { get; set; }
    }
}
