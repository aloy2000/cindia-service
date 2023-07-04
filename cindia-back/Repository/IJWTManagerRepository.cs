using cindia_back.Auth;
using cindia_back.Models.Dto;

namespace cindia_back.Repository;

public interface IJWTManagerRepository
{
    Tokens Authenticate(string tel, string password);
}