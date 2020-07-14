
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopNew.Data;
using ShopNew.Models;

[Route("categories")]
public class CategoryController : ControllerBase
{
    //deixa mais expressivo e claro o desenvolvimento
    [Route("")]
    [HttpGet]
    public async Task<ActionResult<List<Category>>> Pegar([FromServices] DataContext context)
    {
        //asnotracking é uma forma rápida de pegar os dados sem trazer coisas desnecessárias
        var category = await context.Categorys.AsNoTracking().ToListAsync();
        return Ok(category);
    }

    // Essa é o metodo inicial  
    // public string Pegar(){
    //     return "Agora eu peguei - pedi Get";
    // }

    //adicionar o parâmetro com a restrição do tipo -- 
    //dois ponto mais o tipo do parâmetro, impede o erro na utilização 
    [Route("{id:int}")]
    [HttpGet]

    public async Task<ActionResult<Category>> PegarPorId([FromServices] DataContext context, int id)
    {
        var categoria = await context.Categorys.FirstOrDefaultAsync(c => c.Id == id);
        if (categoria == null)
            return NotFound(new { message = $"Categoria não encontrada! {id}" });
        else
            return Ok(categoria);
    }

    // public string PegarPorId(int id){
    //     return "Agora eu peguei - pedi Get = " + id.ToString();
    // }


    [Route("")]
    [HttpPost]
    public async Task<ActionResult<List<Category>>> Gravar([FromBody] Category model,
                                                           [FromServices] DataContext context)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            context.Categorys.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
        }
        catch
        {
            return BadRequest(new { message = "Uops.... deu merda ao gravar !" });
        }


    }
    //original aqui de baixo    
    // public Category Gravar([FromBody]Category model){
    //     return model;
    // }

    [Route("{id:int}")]
    [HttpPut]
    public async Task<ActionResult<List<Category>>> Atualizar(int id, [FromBody] Category m,
    [FromServices] DataContext context)
    {
        if (m.Id != id)
            return NotFound(new { message = "Uops... algo deu errado!" });

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            context.Entry<Category>(m).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(m);
        }
        catch (DbUpdateConcurrencyException)
        {
            return BadRequest(new { message = "Erro ao tentar atualizar - erro de concorrência!" });
        }
        catch
        {
            return BadRequest(new { message = "Erro ao tentar atualizar os dados !" });
        }
    }

    [Route("{id:int}")]
    [HttpDelete]
    public async Task<ActionResult<List<Category>>> Excluir([FromServices] DataContext context, int id)
    {
        var categoria = await context.Categorys.FirstOrDefaultAsync(c => c.Id == id);

        if (categoria == null)
            return NotFound(new { message = "Não foi possível localizar o registro!" });

        try
        {
            context.Categorys.Remove(categoria);
            await context.SaveChangesAsync();
            return Ok(new { message = "Categoria excluída do sistema !" });
        }
        catch
        {
            return BadRequest(new { message = "Problemas ao excluir o registro!" });
        }
    }
}