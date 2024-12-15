using ProyectoBE.Models.Enums;

namespace ProyectoBE.Models
{
    public class RevisionPropuesta
    {
        public int Id { get; set; }
        public string? Comentarios { get; set; }
        public EstadoRevision Estado { get; set; } = EstadoRevision.Pendiente;
        public DateTime FechaRevision { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } // Flag para eliminación lógica
        public DateTime? DeletedAt { get; set; } // Fecha de eliminación (opcional)

        // Relación con Propuesta
        public int IdPropuesta { get; set; }
        public Propuesta Propuesta { get; set; } = null!;

        // Relación con Coordinador
        public int IdCoordinador { get; set; }
        public Coordinador Coordinador { get; set; } = null!;
    }


}
