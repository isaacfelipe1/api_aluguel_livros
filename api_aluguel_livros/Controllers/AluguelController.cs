using api_aluguel_livros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace api_aluguel_livros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AluguelController : ControllerBase
    {
        private readonly LivrosDbContext _context;

        public AluguelController(LivrosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Aluguel> GetAlugueis()
        {
            return _context.Aluguel.Include(a => a.Livro).Include(a => a.Usuario).ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<Aluguel> GetAluguelPorId(int id)
        {
            Aluguel aluguel = _context.Aluguel.Find(id);

            if (aluguel == null)
            {
                return NotFound();
            }

            return aluguel;
        }
        [HttpPost]
        public async Task<ActionResult<Aluguel>> PostAluguel(Aluguel aluguel)
        {
            try
            {
                _context.Aluguel.Add(aluguel);
                await _context.SaveChangesAsync();

                // Carregar propriedades de navegação antes de retornar a resposta
                aluguel = _context.Aluguel
                    .Include(a => a.Livro)
                    .Include(a => a.Usuario)
                    .FirstOrDefault(a => a.Id == aluguel.Id);

                return CreatedAtAction("GetAluguelPorId", new { id = aluguel.Id }, aluguel);
            }
            catch (Exception ex)
            {
                // Registre ou imprima a exceção para fins de depuração
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluguel(int id, Aluguel aluguel)
        {
            if (id != aluguel.Id)
            {
                return BadRequest();
            }
            _context.Entry(aluguel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AluguelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool AluguelExists(int id)
        {
            return _context.Aluguel.Any(e => e.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluguel(int id)
        {
            var aluguel = await _context.Aluguel.FindAsync(id);
            if (aluguel == null)
            {
                return NotFound();
            }

            _context.Aluguel.Remove(aluguel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
