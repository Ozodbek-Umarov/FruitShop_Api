using Domain.Entities;

namespace Application.Interfaces;

public interface IAuthManager
{
    string GetJwtToken(User user);
}
