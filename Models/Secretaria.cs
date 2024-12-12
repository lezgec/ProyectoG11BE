namespace ProyectoBE.Models
{
    public class Secretaria
    {
        public int Id { get; set; }
        public string NombreArchivo { get; set; } = null!;
        public DateTime FechaCarga { get; set; } = DateTime.Now;
    }

}
