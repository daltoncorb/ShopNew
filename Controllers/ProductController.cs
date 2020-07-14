using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopNew.Data;
using ShopNew.Models;

[Route("products")]
public class ProductController : ControllerBase
{

    [Route("")]
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProduct([FromServices] DataContext _context)
    {
        //include faz com que os dados da categoria sejam adicionados. Ele faz um join.
        //Se não precisar dos dados da categoria, não precisa usar o include
        var produtos = await _context.Products.Include(x => x.Category).AsNoTracking().ToListAsync();
        if (produtos == null)
            return NotFound(new { message = "Nenhum item foi localizado no sistema !" });
        else
            return Ok(produtos);
    }

    [Route("id:int")]
    [HttpGet]
    public async Task<ActionResult<Product>> GetProductById([FromServices] DataContext _context, int id)
    {
        //include faz com que os dados da categoria sejam adicionados. Ele faz um join.
        //Se não precisar dos dados da categoria, não precisa usar o include
        var produtos = await _context.Products.Include(x => x.Category).AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        if (produtos == null)
            return NotFound(new { message = "Nenhum item foi localizado no sistema !" });
        else
            return Ok(produtos);
    }

    [Route("categories/{id:int}")]
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProductByCategory([FromServices] DataContext _context, int id)
    {
        //include faz com que os dados da categoria sejam adicionados. Ele faz um join.
        //Se não precisar dos dados da categoria, não precisa usar o include
        //var products = await _context.Products.Include(x => x.Category).AsNoTracking().Where(x => x.CategoryId == id).ToListAsync();

        var produtos = await _context.Products
                                   .Include(x => x.Category)
                                   .AsNoTracking()
                                   .Where(c => c.CategoryId == id)
                                   .ToListAsync();
        //tolistAsync tem que ficar sempre no final
        if (produtos == null)
            return NotFound(new { message = "Nenhum resultado por categoria foi encontrado!" });

        return Ok(produtos);
    }

    [Route("")]
    [HttpPost]
    public async Task<ActionResult<Product>> InsertProdutc([FromBody]Product model, [FromServices] DataContext _context)
    {
        if (!ModelState.IsValid)
            return BadRequest(new { message = "Os dados não foram enviados corretamente!" });

        try
        {
            _context.Products.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }
        catch
        {
            return BadRequest(new { message = "Deu algum problema ao tentar gravar os dados do produto!" });
        }

    }


}