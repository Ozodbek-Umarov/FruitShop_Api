using Application.DTOs.UserDtos;

namespace Application.Interfaces;

public interface IAccountService
{
    Task RegisterAsync(AddUserDto dto);
    Task <string> LoginAsync(LoginDto dto); 
}
