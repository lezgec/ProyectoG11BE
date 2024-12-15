namespace ProyectoBE.Models
{
    public class PropuestaGestor
    {
        public int Id { get; set; }

        // Relación con Propuesta
        public int IdPropuesta { get; set; }
        public Propuesta Propuesta { get; set; } = null!;
        public bool IsDeleted { get; set; } // Flag para eliminación lógica
        public DateTime? DeletedAt { get; set; } // Fecha de eliminación (opcional)

        // Relación con Gestor
        public int IdGestor { get; set; }
        public Gestor Gestor { get; set; } = null!;
    }

}
