
using Microsoft.AspNetCore.Mvc;
[Route("categories")]
public class CategoryController : ControllerBase
{
    public string retornar(){
        return "Agora retornei algo novo";
    }
}