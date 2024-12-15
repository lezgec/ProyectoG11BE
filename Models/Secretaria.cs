namespace ProyectoBE.Models
{
    public class Secretaria
    {
        public int Id { get; set; }
        public string NombreArchivo { get; set; } = null!;
        public DateTime FechaCarga { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } // Flag para eliminación lógica
        public DateTime? DeletedAt { get; set; } // Fecha de eliminación (opcional)
    }

}
