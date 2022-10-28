using ApiCatalago.Context;
using ApiCatalago.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalago.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoriaId = _context.Categorias.FirstOrDefault(x => x.CategoriaId == id);
            if(categoriaId is null)
            {
                return NotFound("Digite a categoria....");
            }
            return categoriaId;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> GetAll()
        {
            var categoriaLista = _context.Categorias.ToList();
            if (categoriaLista is null)
            {
                return NotFound("Produtos não encontrados.....");
            }
            return categoriaLista;
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            try
            {
                if (categoria is null)
                    return BadRequest();

                _context.Add(categoria);
                _context.Entry(categoria).State = EntityState.Added;
                _context.SaveChanges();

                return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }
            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoriaId = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);

            if (categoriaId is null)
            {
                return NotFound("Categoria não localizada...");
            }
            _context.Categorias.Remove(categoriaId);
            _context.SaveChanges();

            return Ok(categoriaId);

        }
    }
}
