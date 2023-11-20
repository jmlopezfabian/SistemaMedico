using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaMedico.Context;
using SistemaMedico.Models;

namespace SistemaMedico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpedienteController
    {
        [HttpGet]
        public JsonResult getExpediente()
        {
            List<Expediente> expedientes = new List<Expediente>();
            using (SistemaContexto contexto = new SistemaContexto())
            {
                var aux = contexto.expedientes;
                foreach (var item in aux)
                {
                    expedientes.Add(new Expediente
                    {
                        Id = item.Id,
                        IdPaciente = item.IdPaciente,
                        FechaCreacion = item.FechaCreacion,
                        UltimaActualizacion = item.UltimaActualizacion,
                        AntecedentesMedicosFam = item.AntecedentesMedicosFam,
                        HistorialVacunacion = item.HistorialVacunacion,
                        ConsumoAlcohol = item.ConsumoAlcohol,
                        Fumador = item.Fumador,
                        ContactoEmergencia = item.ContactoEmergencia,
                        FotosRadiografias = item.FotosRadiografias

                    });

                }
            }
            return new JsonResult(expedientes);
        }

        [HttpPost]
        public JsonResult postExpediente([FromBody] Expediente new_expediente)
        {
            bool validacion = false;
            using (SistemaContexto contexto = new SistemaContexto())
            {
                contexto.expedientes.Add(new_expediente);
                contexto.SaveChanges();
                validacion = true;
            }
            return new JsonResult(validacion);
        }

        [HttpPatch]
        public JsonResult patchExpediente([FromBody] Expediente new_expediente)
        {
            bool validacion = false;
            using (SistemaContexto contexto = new SistemaContexto())
            {
                var existe = contexto.expedientes.SingleOrDefault(i => i.Id == new_expediente.Id);
                if (existe != null)
                {
                    contexto.Entry(existe).State = EntityState.Detached;
                    contexto.expedientes.Attach(new_expediente);
                    contexto.Entry(new_expediente).State = EntityState.Modified;
                    contexto.SaveChanges();
                    validacion = true;
                }

                return new JsonResult(validacion);
            }
        }

        [HttpDelete]
        public JsonResult deleteExpediente([FromBody] int IdExpediente)
        {
            bool validacion = false;
            using (SistemaContexto contexto = new SistemaContexto())
            {
                var existe = contexto.expedientes.SingleOrDefault(i => i.Id == IdExpediente);
                if (existe != null)
                {
                    contexto.Entry(existe).State = EntityState.Detached;
                    contexto.expedientes.Attach(existe);
                    contexto.Entry(existe).State = EntityState.Deleted;
                    contexto.SaveChanges();
                    validacion = true;
                }

                return new JsonResult(validacion);
            }
        }
    }
}