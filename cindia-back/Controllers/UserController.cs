using cindia_back.Models.Dto;
using cindia_back.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cindia_back.Controllers;

public class UserController:Controller
{
    private readonly IJWTManagerRepository _jWTManager;
    
    public UserController(IJWTManagerRepository jWTManager)
    {
        _jWTManager = jWTManager;
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("authenticate")]
    public IActionResult Authenticate(string tel, string password)
    {
        var token = _jWTManager.Autheticate(tel, password);
        if (token == null)
        {
            return Unauthorized();
        }
        return Ok(token);
    }
}