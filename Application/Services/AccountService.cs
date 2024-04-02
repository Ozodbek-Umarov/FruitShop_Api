using Application.Common.Exceptions;
using Application.DTOs.UserDtos;
using Application.Interfaces;
using Application.Securityu;
using Domain.Entities;
using Infrastructures.Interfaces;
using System.Net;

namespace Application.Services;

public class AccountService(IUnitOfWork unitOfWork, IAuthManager auth)
    : IAccountService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IAuthManager _auth = auth;

    public async Task<string> LoginAsync(LoginDto dto)
    {
        var user = await _unitOfWork.User.GetByEmailAsync(dto.Email);

        if (user is null) throw new StatusCodeExeption(HttpStatusCode.NotFound, "User not found!");

        if (!user.Password.Equals(PasswordHasher.GetHash(dto.Password)))
            throw new StatusCodeExeption(HttpStatusCode.Conflict, "Password incorrect!");
        return _auth.GetJwtToken(user);
    }

    public async Task RegisterAsync(AddUserDto dto)
    {
        var user = (User)dto;
        await _unitOfWork.User.AddAsync(user);
    }
}
