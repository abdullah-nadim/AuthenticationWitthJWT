using AuthenticationWitthJWT.DTOs;
using AuthenticationWitthJWT.Entitys;

namespace AuthenticationWitthJWT.Services
{
    public interface IAuthServices
    {
        User Register(User user);
        bool Login(User user);
    }
}
