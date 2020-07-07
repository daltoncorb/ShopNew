
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopNew.Models;

[Route("categories")]
public class CategoryController : ControllerBase
{
    //deixa mais expressivo e claro o desenvolvimento
    [Route("")]
    [HttpGet]
    public async Task<ActionResult<List<Category>>> Pegar(){
        return new List<Category>();
    }

    // Essa é o metodo inicial  
    // public string Pegar(){
    //     return "Agora eu peguei - pedi Get";
    // }

    //adicionar o parâmetro com a restrição do tipo -- 
    //dois ponto mais o tipo do parâmetro, impede o erro na utilização 
    [Route("{id:int}")]
    [HttpGet]

    public async Task<ActionResult<Category>> PegarPorId(int id){
        return new Category();
    }

    // public string PegarPorId(int id){
    //     return "Agora eu peguei - pedi Get = " + id.ToString();
    // }


    [Route("")]
    [HttpPost]
    public async Task<ActionResult<List<Category>>> Gravar([FromBody]Category model){
        return Ok(model);
    }
    //original aqui de baixo    
    // public Category Gravar([FromBody]Category model){
    //     return model;
    // }

    [Route("{id:int}")]
    [HttpPut]
    public Category Atualizar(int id, [FromBody] Category m){
        if (m.Id == id)
        return m;

        return null;
    }     

    [Route("")]
    [HttpDelete]
    public string Excluir(){
        return "Agora eu exclui algo de algum lugar";
    }       
}