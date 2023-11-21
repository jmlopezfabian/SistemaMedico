using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaMedico.Context;
using SistemaMedico.DTO;
using SistemaMedico.Models;

namespace SistemaMedico.Controllers
{
    [Route("LoginController")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public bool login([FromBody] string usuario, string contrasena)
        {
            bool regreso = false;
            using (SistemaContexto contexto = new SistemaContexto())
            {
                var existe = contexto.usuarios.SingleOrDefault(i => i.NombreUsuario == usuario && i.Contrasena == contrasena);
                if (existe != null)
                {
                    regreso = true;
                }
                return regreso;
            }
        }
    }
}