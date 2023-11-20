namespace SistemaMedico.DTO
{
    public class Historial
    {
        public int Id { get; set; }
        public string MedicamentoActual { get; set; }
        public string MedicamentoAnterior { get; set; }
        public string CondicionesMedicasCronicas { get; set; }
        public string Alergias { get; set; }
        public string EnfermedadesPasadas { get; set; }


    }
}
