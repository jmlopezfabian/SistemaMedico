namespace SistemaMedico.DTO
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string Direccion { get; set; }
        public int NSS { get; set; }
    }
}