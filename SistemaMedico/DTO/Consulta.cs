namespace SistemaMedico.DTO
{
    public class Consulta
    {
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public string Sintomas { get; set; }
        public string FechaCreacion { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }
    }
}