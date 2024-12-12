namespace ProyectoBE.Models
{
    public class PropuestaGestor
    {
        public int Id { get; set; }

        // Relación con Propuesta
        public int IdPropuesta { get; set; }
        public Propuesta Propuesta { get; set; } = null!;

        // Relación con Gestor
        public int IdGestor { get; set; }
        public Gestor Gestor { get; set; } = null!;
    }

}
