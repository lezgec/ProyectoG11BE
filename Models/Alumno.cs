namespace ProyectoBE.Models
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string? Telefono { get; set; }
        public string? PropuestaDefinicion { get; set; }
        public bool IsDeleted { get; set; } // Flag para eliminación lógica
        public DateTime? DeletedAt { get; set; } // Fecha de eliminación (opcional)

        // Relación: Un alumno tiene muchas propuestas
        public ICollection<Propuesta> Propuestas { get; set; } = new List<Propuesta>();
    }

}
