using GestorMultiPessoas.Autentication.Model;
using System.ComponentModel.DataAnnotations;
using static GestorMultiPessoas.Autentication.Enums.EnunsAutentication;

namespace GestorMultiPessoas.Autentication.Dto
{
    public class UpdateUsuarioDto
    {
        [StringLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        public string? Nome { get; set; }

        [StringLength(100, ErrorMessage = "O Sobrenome deve ter no máximo 100 caracteres.")]
        public string? Sobrenome { get; set; }

        [StringLength(255, ErrorMessage = "A Senha deve ter no máximo 255 caracteres.")]
        public string? Senha { get; set; }

        [EmailAddress(ErrorMessage = "O Email deve ser válido.")]
        [StringLength(255, ErrorMessage = "O Email deve ter no máximo 255 caracteres.")]
        public string? Email { get; set; }

        [StringLength(15, ErrorMessage = "O Celular deve ter no máximo 15 caracteres.")]
        [RegularExpression(@"^\+?\d{10,15}$", ErrorMessage = "O Celular deve ser válido.")]
        public string? Celular { get; set; }

        public PerfilUsuario? Perfil { get; set; }
    }
}
