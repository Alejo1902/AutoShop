using System.ComponentModel.DataAnnotations;

namespace AutoShopManager.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Telefono { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Direccion { get; set; }

        public ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
