using FirstWebApi.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApi.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class AutoresController: ControllerBase
    {
        private readonly ApplicatonDbContext _context;
        public AutoresController(ApplicatonDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {
            return await _context.Autores.Include(x => x.Libros).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult>Post(Autor autor)
        {
            _context.Add(autor);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")] //api/autores/id
        public async Task<ActionResult>Put(Autor autor, int id)
        {
            if (autor.Id != id)
            {
                return BadRequest("El id del autor no coincide con la del URL");
            }

            _context.Update(autor);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]//El int va pegado a la variable del path
        public async Task<ActionResult>Delete(int id)
        {
            var exist = await _context.Autores.AnyAsync(x => x.Id == id);
            if (!exist) 
            {
                return NotFound();
            }

            _context.Remove(new Autor() { Id = id });
            await _context.SaveChangesAsync();
            return Ok(); 
        }
    }
}
