using Domain.Entities;
using Domain.Enums;

namespace Application.DTOs.UserDtos;

public class AddUserDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserRole UserRole { get; set; } = UserRole.User;

    public static implicit operator User(AddUserDto dto)
    {
        return new User()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Phone = dto.Phone,
            Email = dto.Email,
            Password = dto.Password,

        };
    }
}
