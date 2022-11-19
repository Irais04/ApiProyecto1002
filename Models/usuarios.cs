using System.ComponentModel.DataAnnotations;

namespace ApiProyecto1002.Models
{
    public class usuarios
    {
        [Key]
        public int id { get; set; }
        public string? nombre { get; set; }
        public int Edad { get; set; }
        public string? Correo { get; set; }

    }
}
