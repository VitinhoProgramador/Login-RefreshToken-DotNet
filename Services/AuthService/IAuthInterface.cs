using APIrest.DTOs;
using APIrest.Models;

namespace APIrest.Services.AuthService
{
    public interface IAuthInterface
    {
        Task<Response<UsuarioRegisterDto>> Registrar(UsuarioRegisterDto usuarioRegister);
        Task<Response<string>> Login(UsuarioLoginDto usuarioLogin);
    }
}
