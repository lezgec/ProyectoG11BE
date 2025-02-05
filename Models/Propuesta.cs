namespace ProyectoBE.Models
{
    public class Propuesta
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Definicion { get; set; } = null!;
        public string Archivo { get; set; } = null!;
        public bool IsDeleted { get; set; } // Eliminación lógica
        public DateTime? DeletedAt { get; set; } // Fecha de eliminación (opcional)
        public string Estado { get; set; } = "En Revisión"; // Estado inicial por defecto
        public DateTime FechaSubida { get; set; } = DateTime.Now;
        public DateTime? FechaModificacion { get; set; }
        public string? Observaciones { get; set; }

        // Relación: Una propuesta puede tener hasta 2 alumnos asignados
        public int? Alumno1Id { get; set; }
        public int? Alumno2Id { get; set; }

        // Relación: Una propuesta tiene UN revisor (Gestor/Docente)
        public int? RevisorId { get; set; }
    }
}

