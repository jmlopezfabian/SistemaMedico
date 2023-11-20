namespace SistemaMedico.Models
{
    public class Expediente
    {
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public string FechaCreacion { get; set; }
        public string UltimaActualizacion { get; set; }
        public string AntecedentesMedicosFam { get; set; }
        public string HistorialVacunacion { get; set; }
        public bool ConsumoAlcohol { get; set; }
        public bool Fumador { get; set; }
        public string ContactoEmergencia { get; set; }
        public string FotosRadiografias { get; set; }
    }
}