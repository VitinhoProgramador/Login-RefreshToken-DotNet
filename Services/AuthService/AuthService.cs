using APIrest.Data;
using APIrest.DTOs;
using APIrest.Models;
using APIrest.Services.SenhaService;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace APIrest.Services.AuthService
{
    public class AuthService : IAuthInterface
    {
        private readonly AppDbContext _context;
        private readonly ISenhaInterface _senhaInterface;
        public AuthService(AppDbContext context, ISenhaInterface senhaInterface)
        {
            _context = context;
            _senhaInterface = senhaInterface;
        }

        public async Task<Response<UsuarioRegisterDto>> Registrar(UsuarioRegisterDto usuarioRegister)
        {
            Response<UsuarioRegisterDto> respostaService = new Response<UsuarioRegisterDto>();

            try
            {
                if (!VerificaSeEmaileUsuarioExiste(usuarioRegister))
                {
                    respostaService.Dados = null;
                    respostaService.Status = false;
                    respostaService.Menssagem = "Email/Usuario ja cadastrado";
                    return respostaService;
                }

                _senhaInterface.CriarSenhaHash(usuarioRegister.Senha, out byte[] senhaHash, out byte[] senhaSalt);



                UsuarioModel usuario = new UsuarioModel()
                {
                    Usuario = usuarioRegister.Usuario,
                    Email = usuarioRegister.Email,
                    Cargo = usuarioRegister.Cargo,
                    SenhaHash = senhaHash,
                    SenhaSalt = senhaSalt,
                    Papel = "Usuario Comum", 
                    DataRegistro = DateTime.UtcNow, 
                    TokenDataCriacao = DateTime.UtcNow,
                    Anonimizado = false,
                    TrusScore = 0,
                    XpTotal = 0,
                    NivelAtual = 1
                };


                _context.Add(usuario);
                await _context.SaveChangesAsync();

                respostaService.Menssagem = "Usuario criado com sucesso";






            }
            catch (Exception ex)
            {
                respostaService.Dados = null;
                respostaService.Menssagem = ex.Message;
                respostaService.Status = false;

            }
            return respostaService;

        }



        public async Task<Response<string>> Login(UsuarioLoginDto usuarioLogin)
        {
            Response<string> respostaService = new Response<string>();
            try
            {
                var usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.Email == usuarioLogin.Email);

                if (usuario == null || !_senhaInterface.VerificaSenhaHash(usuarioLogin.senha, usuario.SenhaHash, usuario.SenhaSalt))
                {
                    respostaService.Menssagem = "Credenciais Inválidas";
                    respostaService.Status = false;
                    return respostaService;
                }

                
                var token = _senhaInterface.CriarToken(usuario);
                var refreshToken = _senhaInterface.GerarRefreshToken();

                
                usuario.RefreshToken = refreshToken;
                usuario.TokenDataExpiracao = DateTime.UtcNow.AddDays(7); 

                _context.Update(usuario);
                await _context.SaveChangesAsync();

                respostaService.Dados = token; 
                respostaService.Menssagem = refreshToken; 
                respostaService.Status = true;
            }
            catch (Exception ex) {  }
            return respostaService;
        }


        public bool VerificaSeEmaileUsuarioExiste(UsuarioRegisterDto usuarioRegister)
        {
            var usuario = _context.Usuario.FirstOrDefault(userBanco => userBanco.Email == usuarioRegister.Email || userBanco.Usuario == usuarioRegister.Usuario);

            if (usuario != null) return false;

            return true;
        }

    }
}
