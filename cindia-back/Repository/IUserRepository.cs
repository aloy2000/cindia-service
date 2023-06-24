using cindia_back.Models.Dto;

namespace cindia_back.Repository;

public interface IUserRepository
{
    Task<IEnumerable<UserDto>> GetUser();
    Task<UserDto> GetUserById(int userId); 
    Task<UserDto> UpdateUser( UserDto userDto);
    Task<bool> DeleteUser(int userId);
    Task<UserDto> FindUserByNum(string numTel);
}