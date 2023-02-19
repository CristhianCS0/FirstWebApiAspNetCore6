using FirstWebApi.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApi.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController: ControllerBase
    {
        private readonly ApplicatonDbContext _context;

        public LibrosController(ApplicatonDbContext context)
        {
            this._context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Libro>> Get(int id)
        {
            return await _context.Libros.Include(x => x.Autor).FirstOrDefaultAsync(x => x.id == id); 
        }

        [HttpPost]
        public async Task<ActionResult> Post(Libro libro)
        {
            var exist = await _context.Autores.AnyAsync(x => x.Id == libro.AutorId);
            if (!exist)
            {
                return BadRequest($"El ID: {libro.AutorId} no existe.");
            }
            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}