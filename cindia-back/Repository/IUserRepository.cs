using cindia_back.Models.Dto;

namespace cindia_back.Repository;

public interface IUserRepository
{
    Task<IEnumerable<CasierDto>> GetUser();
    Task<UserDto> GetUserById(int UserId); 
    Task<UserDto> UpdateUser( UserDto UserDto);
    Task<UserDto> DeleteUser(int UserId); 
}