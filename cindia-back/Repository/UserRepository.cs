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
        List<User> users = await _db.Users.ToListAsync();
        return _mapper.Map<List<UserDto>>(users);
    }

    public Task<UserDto> GetUserById(int UserId)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> UpdateUser(UserDto UserDto)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> DeleteUser(int UserId)
    {
        throw new NotImplementedException();
    }
}