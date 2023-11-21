using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaMedico.Context;
using SistemaMedico.Models;

namespace SistemaMedico.Controllers
{
    [Route("ConsultaController")]
    [ApiController]
    public class ConsultaController
    {
        [HttpGet]
        public JsonResult getConsulta()
        {
            List<Consulta> usuarios = new List<Consulta>();
            using (SistemaContexto contexto = new SistemaContexto())
            {
                var aux = contexto.consultas;
                foreach (var item in aux)
                {
                    usuarios.Add(new Consulta
                    {
                        Id = item.Id,
                        IdPaciente = item.IdPaciente,
                        Sintomas = item.Sintomas,
                        FechaCreacion = item.FechaCreacion,
                        Diagnostico = item.Diagnostico,
                        Tratamiento = item.Diagnostico

                    });
                }
            }
            return new JsonResult(usuarios);
        }

        [HttpPost]
        public JsonResult postConsulta([FromBody] Consulta new_consulta)
        {
            bool validacion = false;
            using (SistemaContexto contexto = new SistemaContexto())
            {
                contexto.consultas.Add(new_consulta);
                contexto.SaveChanges();
                validacion = true;
            }
            return new JsonResult(validacion);
        }


        [HttpPatch]
        public JsonResult patchConsulta([FromBody] Consulta new_consulta)
        {
            bool validacion = false;
            using (SistemaContexto contexto = new SistemaContexto())
            {
                var existe = contexto.consultas.SingleOrDefault(i => i.Id == new_consulta.Id);
                if (existe != null)
                {
                    contexto.Entry(existe).State = EntityState.Detached;
                    contexto.consultas.Attach(new_consulta);
                    contexto.Entry(new_consulta).State = EntityState.Modified;
                    contexto.SaveChanges();
                    validacion = true;
                }

                return new JsonResult(validacion);
            }
        }

        [HttpDelete]
        public JsonResult patchConsulta([FromBody] int id_consulta)
        {
            bool validacion = false;
            using (SistemaContexto contexto = new SistemaContexto())
            {
                var existe = contexto.consultas.SingleOrDefault(i => i.Id == id_consulta);
                if (existe != null)
                {
                    contexto.Entry(existe).State = EntityState.Detached;
                    contexto.consultas.Attach(existe);
                    contexto.Entry(existe).State = EntityState.Deleted;
                    contexto.SaveChanges();
                    validacion = true;
                }

                return new JsonResult(validacion);
            }
        }


    }
}
