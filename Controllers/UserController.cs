
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopNew.Data;
using ShopNew.Models;
using ShopNew.Services;

[Route("users")]
public class UserController : ControllerBase
{

    [Route("")]
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<User>> AddUser([FromBody] User model, [FromServices] DataContext _context)
    {
        if (!ModelState.IsValid)
            return BadRequest(new { message = $"Tivemos um problema ao cadastrar o usuário {model.Username} !" });

        _context.Users.Add(model);
        await _context.SaveChangesAsync();

        return Ok(new { message = $"Usuário registrado com sucesso - {model.Username} !" });
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("login")]
    public async Task<ActionResult<dynamic>> Authenticate([FromBody]User model, [FromServices]DataContext _context)
    {

        var user = await _context.Users
                .AsNoTracking()
                .Where(u => u.Username == model.Username && u.Password == model.Password)
                .FirstOrDefaultAsync();

        if (user == null)
        return NotFound(new {message = "Usuário não encontrado! Verifique usuário e senhas digitados !"});

        var token = TokenService.GenerateToken(user);

        return new {
            usuario = user.Username,
            token = token
        };
    

        // return Ok(new {message = "Login efetuado com sucesso !"});
    }

}