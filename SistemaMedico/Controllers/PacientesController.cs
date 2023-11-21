using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaMedico.Context;
using SistemaMedico.Models;

namespace SistemaMedico.Controllers
{
    [Route("PacientesController")]
    [ApiController]
    public class PacienteController
    {
        [HttpGet]
        public JsonResult getPaciente()
        {
            List<Paciente> pacientes = new List<Paciente>();
            using (SistemaContexto contexto = new SistemaContexto())
            {
                var aux = contexto.pacientes;
                foreach (var item in aux)
                {
                    pacientes.Add(new Paciente
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        Apellidos = item.Apellidos,
                        FechaNacimiento = item.FechaNacimiento,
                        Genero = item.Genero,
                        Direccion = item.Direccion,
                        NSS = item.NSS

                    });

                }
            }
            return new JsonResult(pacientes);
        }

        [HttpPost]
        public JsonResult postPaciente([FromBody] Paciente new_paciente)
        {
            bool validacion = false;
            using (SistemaContexto contexto = new SistemaContexto())
            {
                contexto.pacientes.Add(new_paciente);
                contexto.SaveChanges();
                validacion = true;
            }
            return new JsonResult(validacion);
        }

        [HttpPatch]
        public JsonResult patchPaciente([FromBody] Paciente new_paciente)
        {
            bool validacion = false;
            using (SistemaContexto contexto = new SistemaContexto())
            {
                var existe = contexto.pacientes.SingleOrDefault(i => i.Id == new_paciente.Id);
                if (existe != null)
                {
                    contexto.Entry(existe).State = EntityState.Detached;
                    contexto.pacientes.Attach(new_paciente);
                    contexto.Entry(new_paciente).State = EntityState.Modified;
                    contexto.SaveChanges();
                    validacion = true;
                }

                return new JsonResult(validacion);
            }
        }

        [HttpDelete]
        public JsonResult deletePaciente([FromBody] int IdPaciente)
        {
            bool validacion = false;
            using (SistemaContexto contexto = new SistemaContexto())
            {
                var existe = contexto.pacientes.SingleOrDefault(i => i.Id == IdPaciente);
                if (existe != null)
                {
                    contexto.Entry(existe).State = EntityState.Detached;
                    contexto.pacientes.Attach(existe);
                    contexto.Entry(existe).State = EntityState.Deleted;
                    contexto.SaveChanges();
                    validacion = true;
                }

                return new JsonResult(validacion);
            }
        }
    }
}
