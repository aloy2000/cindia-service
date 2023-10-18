using cindia_back.Models.Dto;
using cindia_back.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static cindia_back.utils.Utils;


namespace cindia_back.Controllers;

[Route("api/[controller]")]

public class UserController : Controller
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
    public async Task<IActionResult> Authenticate([FromBody] AuthDto authDto)
    {
        var user = await _userRepository.FindUserByNum(authDto.Tel);
        if (user == null)
        {
            return NotFound();
        }
        if (user.Password != authDto.Password)
        {
            return Unauthorized();
        }

        var token = _jWtManager.Authenticate(user.Tel, user.Password);
        if (token == null)
        {
            return Unauthorized();
        }
        var response = new Dictionary<string, object>();
        response["token"] = token;
        response["user"] = user;
        return Ok(response);
    }

    [HttpPost]
    [Route("register")]
    public async Task<object> Create([FromBody] UserDto userDto)
    {
        try
        {
            var userWithExistingCin = await _userRepository.FindUserByNum(userDto?.NumCIN);
            System.Console.WriteLine("userWithExistingCin:" + userWithExistingCin);
            if (userWithExistingCin != null)
            {
                _responseDto.IsSuccess = false;
                _responseDto.DisplayMessage = "User with this num Cin already exist";
                return _responseDto;
            }
            var numCinToChar = userDto.NumCIN?.ToCharArray();
            var sexNumber = Char.GetNumericValue(numCinToChar[5]);
            if (sexNumber % 2 == 0)
            {
                userDto.Sex = "Feminin";
            }
            else
            {
                userDto.Sex = "Masculin";
            }
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
    public async Task<object> Get(int page = 1, int size = 1)
    {
        try
        {
            var users = await _userRepository.GetUser();
            var paginateUsers = Paginate<UserDto>(users, page, size);
            _responseDto.Result = paginateUsers;
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