using APIrest.Enum;
using System.ComponentModel.DataAnnotations;

namespace APIrest.DTOs
{
    public class UsuarioRegisterDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatorio")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "O campo email é obrigatorio"), EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo senha é obrigatorio")]
        public string Senha { get; set; }
        [Compare("Senha", ErrorMessage = "Senhas não conincidem")]
        
        public string ConfirmaSenha { get; set; }
        [Required(ErrorMessage = "O campo Cargo é obrigatorio")]
        public CargoEnum Cargo { get; set; }
    }
}
