using Application.DTOs.UserDtos;
using Application.Interfaces;
using Domain.Entities;
using Infrastructures.Interfaces;

namespace Application.Services;

public class AccountService(IUnitOfWork unitOfWork, IAuthManager auth)
    : IAccountService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IAuthManager _auth = auth;

    public async Task<string> LoginAsync(LoginDto dto)
    {
        var user = await _unitOfWork.User.GetByEmailAsync(dto.Email);
        if (user == null)
            return "not found";
        if (user.Password != dto.Password)
            return "Password not Valid";
        return _auth.GetJwtToken(user);
    }

    public async Task RegisterAsync(AddUserDto dto)
    {
        var user = (User)dto;
        await _unitOfWork.User.AddAsync(user);
    }
}
