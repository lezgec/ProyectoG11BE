using ProyectoBE.Models.Enums;

namespace ProyectoBE.Models
{
    public class RevisionPropuesta
    {
        public int Id { get; set; }
        public string? Comentarios { get; set; }
        public EstadoRevision Estado { get; set; } = EstadoRevision.Pendiente;
        public DateTime FechaRevision { get; set; } = DateTime.Now;

        // Relación con Propuesta
        public int IdPropuesta { get; set; }
        public Propuesta Propuesta { get; set; } = null!;

        // Relación con Coordinador
        public int IdCoordinador { get; set; }
        public Coordinador Coordinador { get; set; } = null!;
    }


}
