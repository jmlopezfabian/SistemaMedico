using Microsoft.AspNetCore.Mvc;
using SistemaMedico.Context;
using Microsoft.EntityFrameworkCore;
using SistemaMedico.Models;

namespace SistemaMedico.Context
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialController
    {
        [HttpGet]
        public JsonResult getHistoriales()
        {
            List<Historial> historiales = new List<Historial>();

            using (SistemaContexto contexto = new SistemaContexto())
            {
                var aux = contexto.historiales;
                foreach(var item in aux)
                {
                    historiales.Add(new Historial
                    {
                        Id = item.Id,
                        MedicamentoActual = item.MedicamentoActual,
                        MedicamentoAnterior = item.MedicamentoAnterior,
                        CondicionesMedicasCronicas = item.CondicionesMedicasCronicas,
                        Alergias = item.Alergias,
                        EnfermedadesPasadas = item.EnfermedadesPasadas
                    }) ;
                }
            }
            return new JsonResult(historiales);
        }

        [HttpPost]
        public JsonResult postHistorial([FromBody] Historial new_historial)
        {
            bool validacion = false;

            using (SistemaContexto contexto = new SistemaContexto())
            {
                contexto.historiales.Add(new_historial);
                contexto.SaveChanges();
                validacion = true;
            }
                return new JsonResult(validacion);
        }
        [HttpPatch]
        public JsonResult patchHistorial([FromBody] Historial new_historial)
        {
            bool validacion = false;
            using (SistemaContexto contexto = new SistemaContexto())
            {
                var existe = contexto.historiales.SingleOrDefault(i => i.Id == new_historial.Id);
                if (existe != null)
                {
                    contexto.Entry(existe).State = EntityState.Detached;
                    contexto.historiales.Attach(new_historial);
                    contexto.Entry(new_historial).State = EntityState.Modified;
                    contexto.SaveChanges();
                    validacion = true;
                }
            }
            return new JsonResult(validacion);
        }

        [HttpDelete]
        public JsonResult deleteUsuario([FromBody] int id_historial)
        {
            bool validacion = false;
            using (SistemaContexto contexto = new SistemaContexto())
            {
                var existe = contexto.historiales.SingleOrDefault(i => i.Id == id_historial);
                if (existe != null)
                {
                    contexto.Entry(existe).State = EntityState.Detached;
                    contexto.historiales.Attach(existe);
                    contexto.Entry(existe).State = EntityState.Deleted;
                    contexto.SaveChanges();
                    validacion = true;
                }

                return new JsonResult(validacion);
            }
        }
    }
}
