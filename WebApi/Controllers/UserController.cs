using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Services;
using Core.Models;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserServices _services;

        public UserController(IUserServices services)
        {
            _services = services;
        }

        [HttpPost]
        public IActionResult Add(Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.Nombre))
            {
                return BadRequest("El nombre es obligatorio.");
            }

            if (string.IsNullOrEmpty(usuario.Apellido))
            {
                return BadRequest("El apellido es obligatorio.");
            }

            if (string.IsNullOrEmpty(usuario.Email))
            {
                return BadRequest("El email es obligatorio.");
            }

            if (string.IsNullOrEmpty(usuario.Edad.ToString()) || usuario.Edad <= 0)
            {
                return BadRequest("La edad debe ser un número positivo.");
            }

            _services.CreateUser(usuario.Nombre, usuario.Apellido, usuario.Email, usuario.Edad, DateTime.Now);

            return NoContent();

        }

        [HttpGet("all")]
        public List<Usuario> Get()
        {
            var users = _services.ReadUsers();

            return users;
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(int id)
        {
            var users = _services.ReadUsers();
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

    }
}
