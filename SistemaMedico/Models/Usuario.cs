namespace SistemaMedico.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string FechaNacimiento { get; set; }
        public string Contrasena { get; set; }
        public string CorreoElectronico { get; set; }

    }
}