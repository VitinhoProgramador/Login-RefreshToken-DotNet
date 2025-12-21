using APIrest.Enum;
using Microsoft.VisualBasic;

namespace APIrest.Models
{
    public class UsuarioModel
    {
        public int id { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public byte[] SenhaHash { get; set; }
        public byte[] SenhaSalt { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenDataExpiracao { get; set; }
        public CargoEnum Cargo { get; set; }

        public string Papel { get; set; } = "User";
        public DateTime DataRegistro { get; set; } = DateTime.UtcNow;
        public DateTime TokenDataCriacao { get; set; } = DateTime.UtcNow;

        public bool Anonimizado { get; set; } = false;
        public int TrusScore { get; set; } = 0;
        public int XpTotal { get; set; } = 0;
        public int NivelAtual { get; set; } = 1;
    }
}
    