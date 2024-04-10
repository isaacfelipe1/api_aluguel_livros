using api_aluguel_livros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace api_aluguel_livros.Controllers
{
    [Route("api/Usuario")]
    [ApiController]

    public class UsuariosController : ControllerBase
    {
        //Construindo o construtor
        private readonly LivrosDbContext _context;
        public UsuariosController(LivrosDbContext context)
        {
            _context = context;
        }
        //Adicionando o metodo get, ele devolve todos os Usuarios no banco de dados
        //(Uma coleção de Usuarios)
        //
        [HttpGet]
        public IEnumerable<Usuario> GetUsuarios()
        {
            return _context.Usuarios;
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> GetUsuarioPorId(int id)
        {
            Usuario usuario = _context.Usuarios.SingleOrDefault(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpPost]
        public IActionResult CriarUsuario([FromBody] Usuario item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _context.Usuarios.Add(item);
            _context.SaveChanges();
            return CreatedAtAction("GetUsuarios", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarUsuario(int id, [FromBody] Usuario item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteUsuario(int id)
        {
            var usuario = _context.Usuarios.SingleOrDefault(m => m.Id == id);
            if (usuario == null)
            {
                return BadRequest();
            }
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return Ok();
        }

    }

}
