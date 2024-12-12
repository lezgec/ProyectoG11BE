﻿namespace ProyectoBE.Models
{
    public class Gestor
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string? Telefono { get; set; }

        // Relación: Un gestor puede gestionar muchas propuestas
        public ICollection<PropuestaGestor> PropuestaGestores { get; set; } = new List<PropuestaGestor>();
    }

}
