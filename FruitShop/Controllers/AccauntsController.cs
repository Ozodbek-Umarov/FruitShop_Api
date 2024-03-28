using Application.DTOs.UserDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitShop.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccauntsController(IAccountService accountService) : ControllerBase
{
    private readonly IAccountService _accountService = accountService;

    [HttpPost("Register")]
    public async Task <IActionResult> CreateAsyns([FromForm]AddUserDto dto)
    {
        await _accountService.RegisterAsync(dto);
        return Ok();
    }

    [HttpPost("Login")]
    public async Task<IActionResult> LoginAsync([FromForm]LoginDto loginDto)
        => Ok(await _accountService.LoginAsync(loginDto));
}
