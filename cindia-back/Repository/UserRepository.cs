using AutoMapper;
using cindia_back.DbContext;
using cindia_back.Models;
using cindia_back.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace cindia_back.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public UserRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }


    public async Task<IEnumerable<UserDto>> GetUser()
    {
        var users = await _db.Users.ToListAsync();
        return _mapper.Map<List<UserDto>>(users);
    }

    public async Task<UserDto> GetUserById(int userId)
    {
        var user = await _db.Users.Where(user => user.UserId == userId).FirstOrDefaultAsync();
        return _mapper.Map<UserDto>(user);
    }

    public Task<UserDto> UpdateUser(UserDto UserDto)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteUser(int userId)
    {
        try
        {
            var userToDelete = await _db.Users.FirstOrDefaultAsync(user => user.UserId == userId);
            if (userToDelete is null)
            {
                return false;
            }

            _db.Users.Remove(userToDelete);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<UserDto> CreateUser(UserDto userDto)
    {
        User user = _mapper.Map<UserDto, User>(userDto);
        //System.Console.WriteLine("User repository from dto:", user);

        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return _mapper.Map<User, UserDto>(user);
    }

    public async Task<UserDto> FindUserByNum(string numTel)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Tel == numTel);
        if (user is null)
        {
            return null;
        }
        return _mapper.Map<User, UserDto>(user);
    }


}