namespace ProyectoBE.Models
{
    public class Coordinador
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string? Telefono { get; set; }
        public bool IsDeleted { get; set; } // Flag para eliminación lógica
        public DateTime? DeletedAt { get; set; } // Fecha de eliminación (opcional)

        // Relación: Un coordinador puede revisar muchas propuestas
        public ICollection<RevisionPropuesta> Revisiones { get; set; } = new List<RevisionPropuesta>();
    }
}

