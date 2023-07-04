using cindia_back.Models.Dto;
using cindia_back.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cindia_back.Controllers;

[Route("api/[controller]")]

public class UserController:Controller
{
    private readonly IJWTManagerRepository _jWtManager;
    private readonly IUserRepository _userRepository;
    private readonly ResponseDto _responseDto;

    
    public UserController(IJWTManagerRepository jwtManager, IUserRepository userRepository)
    {
        _jWtManager = jwtManager;
        _userRepository = userRepository;
        _responseDto = new ResponseDto();
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("authenticate")]
    public async Task<IActionResult> Authenticate(string tel, string password)
    {
        var user =  await _userRepository.FindUserByNum(tel);
        if (user == null)
        {
            return NotFound();
        }

        if (user.Password != password)
        {
            return Unauthorized();
        }
        
        var token = _jWtManager.Authenticate(tel, password);
        if (token == null)
        {
            return Unauthorized();
        }
        return Ok(token);
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("register")]
    public async Task<object> Create(UserDto userDto, string publicKey)
    {
        
        
        Console.WriteLine("userDto" + userDto);
        try
        {
            UserDto user = null;
            user.Password = PasswordEncryption.EncryptPassword(user.Password, publicKey);

            _userRepository.CreateUser(user);

            var userCreated = await _userRepository.CreateUser(userDto);
            _responseDto.Result = userCreated;
            _responseDto.DisplayMessage = "user created successful";
        }
        catch (Exception e)
        {
            _responseDto.IsSuccess = false;
            _responseDto.ErrorMessage = new List<string>() { e.ToString() };
        }

        return _responseDto;
    }


    [HttpGet]
    public async Task<object> Get()
    {
        try
        {
            var users = await _userRepository.GetUser();
            _responseDto.Result = users;
        }
        catch (Exception e)
        {
            _responseDto.IsSuccess = false;
            _responseDto.ErrorMessage = new List<string>() { e.ToString() };
        }
        return _responseDto;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<object> Get(int id)
    {
        try
        {
            var user = await _userRepository.GetUserById(id);
            _responseDto.Result = user;
        }
        catch (Exception e)
        {
            _responseDto.IsSuccess = false;
            _responseDto.ErrorMessage = new List<string>() { e.ToString() };
        }
        return _responseDto;
    }

    [HttpDelete]
    public async Task<object> Delete(int id)
    {
        try
        {
            var result = await _userRepository.DeleteUser(id);
            _responseDto.Result = result;
        }
        catch (Exception e)
        {
            _responseDto.IsSuccess = false;
            _responseDto.ErrorMessage = new List<string>() { e.ToString() };
        }

        return _responseDto;
    }
}