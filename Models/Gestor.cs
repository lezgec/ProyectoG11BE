namespace ProyectoBE.Models
{
    public class Gestor
    {
        public int Id { get; set; }
        public string Cedula { get; set; } = null!; // Nueva propiedad agregada
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string? Telefono { get; set; }
        public string Rol { get; set; } = null!; // Nueva propiedad agregada

        public bool IsDeleted { get; set; } // Flag para eliminación lógica
        public DateTime? DeletedAt { get; set; } // Fecha de eliminación (opcional)

        public List<int>? PropuestasIds { get; set; } = new List<int>();
    }
}
