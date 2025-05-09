using GestorMultiPessoas.Autentication.Model;
using System.ComponentModel.DataAnnotations;

namespace GestorMultiPessoas.Autentication.Dto
{
    public class CreateUsuarioDto
    {
        [Required(ErrorMessage = "A Senha é obrigatória.")]
        [StringLength(255, ErrorMessage = "A Senha deve ter no máximo 255 caracteres.")]
        public required string Senha { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O Email deve ser válido.")]
        [StringLength(255, ErrorMessage = "O Email deve ter no máximo 255 caracteres.")]
        public required string Email { get; set; }

        [StringLength(15, ErrorMessage = "O Celular deve ter no máximo 15 caracteres.")]
        [RegularExpression(@"^\+?\d{10,15}$", ErrorMessage = "O Celular deve ser válido.")]
        public string? Celular { get; set; }

        [Required(ErrorMessage = "O Perfil é obrigatório.")]
        public required PerfilUsuario Perfil { get; set; }
    }

}
