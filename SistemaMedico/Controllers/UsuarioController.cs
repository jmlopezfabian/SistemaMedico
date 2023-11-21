using Microsoft.AspNetCore.Mvc;
using SistemaMedico.Context;
using Microsoft.EntityFrameworkCore;
using SistemaMedico.Models;

namespace SistemaMedico.Controllers
{

    [Route("UsuarioController")]
    [ApiController]
    public class UsuarioController
    {
        [HttpGet]
        public JsonResult getUsuario()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (SistemaContexto contexto = new SistemaContexto())
            {
                var aux = contexto.usuarios;
                foreach (var item in aux)
                {
                    usuarios.Add(new Usuario
                    {
                        Id = item.Id,
                        NombreUsuario = item.NombreUsuario,
                        NombreCompleto = item.NombreCompleto,
                        FechaNacimiento = item.FechaNacimiento,
                        CorreoElectronico = item.CorreoElectronico

                    });
                }
            }
            return new JsonResult(usuarios);
        }

        [HttpPost]
        public JsonResult postUsuario([FromBody] Usuario new_usuario)
        {
            bool validacion = false;
            using (SistemaContexto contexto = new SistemaContexto())
            {
                contexto.usuarios.Add(new_usuario);
                contexto.SaveChanges();
                validacion = true;
            }
            return new JsonResult(validacion);
        }

        [HttpPatch]
        public JsonResult patchUsuario([FromBody] Usuario new_usuario)
        {
            bool validacion = false;
            using (SistemaContexto contexto = new SistemaContexto())
            {
                var existe = contexto.usuarios.SingleOrDefault(i => i.Id == new_usuario.Id);
                if (existe != null)
                {
                    contexto.Entry(existe).State = EntityState.Detached;
                    contexto.usuarios.Attach(new_usuario);
                    contexto.Entry(new_usuario).State = EntityState.Modified;
                    contexto.SaveChanges();
                    validacion = true;
                }

                return new JsonResult(validacion);
            }
        }

        [HttpDelete]
        public JsonResult deleteUsuario([FromBody] int id_usuario)
        {
            bool validacion = false;
            using (SistemaContexto contexto = new SistemaContexto())
            {
                var existe = contexto.usuarios.SingleOrDefault(i => i.Id == id_usuario);
                if (existe != null)
                {
                    contexto.Entry(existe).State = EntityState.Detached;
                    contexto.usuarios.Attach(existe);
                    contexto.Entry(existe).State = EntityState.Deleted;
                    contexto.SaveChanges();
                    validacion = true;
                }

                return new JsonResult(validacion);
            }
        }


    }
}