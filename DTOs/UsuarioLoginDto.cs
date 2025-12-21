using System.ComponentModel.DataAnnotations;

namespace APIrest.DTOs
{
    public class UsuarioLoginDto
    {
        [Required(ErrorMessage = "O campo email é obrigatorio"), EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo senha é obrigatorio")]
        public string senha { get; set; }
    }
}
