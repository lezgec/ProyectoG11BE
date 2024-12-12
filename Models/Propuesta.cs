namespace ProyectoBE.Models
{
    public class Propuesta
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Estado { get; set; } = "Pendiente"; // Valores posibles: Pendiente, Aprobada, Rechazada
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Relación: Una propuesta pertenece a un alumno
        public int IdAlumno { get; set; }
        public Alumno Alumno { get; set; } = null!;

        // Relación: Una propuesta puede tener muchos gestores
        public ICollection<PropuestaGestor> PropuestaGestores { get; set; } = new List<PropuestaGestor>();

        // Relación: Una propuesta puede tener revisiones
        public ICollection<RevisionPropuesta> Revisiones { get; set; } = new List<RevisionPropuesta>();
    }

}
