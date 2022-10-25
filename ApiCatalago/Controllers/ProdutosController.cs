using ApiCatalago.Context;
using ApiCatalago.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalago.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produtos>> Get()
        {
            var produtos = _context.Produtos.ToList();
            if (produtos is null)
            {
                return NotFound("Produtos não encontrados.....");
            }
            return produtos;
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produtos> Get(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produto is null)
            {
                return NotFound("Produto não encontrado...");
            }
            return produto;
        }

        [HttpPost]
        public ActionResult Post(Produtos produto)
        {
            try
            {
                if (produto is null)
                    return BadRequest();

                _context.Produtos.Add(produto);
                _context.Entry(produto).State = EntityState.Added;
                _context.SaveChanges();

                return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        //[HttpPost("{id:int}")]
        //public ActionResult PostRelatorio(int id)
        //{
        //    if(id is null)
        //    {
        //        return BadRequest();
        //    }
        //}

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produtos produtos)
        {
            if(id != produtos.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produtos).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produtos);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(x => x.ProdutoId == id);
            if(produto is null)
            {
                return NotFound("Produto não localizado");
            }
            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);

        }
    }

}
