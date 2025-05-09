using System.ComponentModel.DataAnnotations;

namespace GestorMultiPessoas.Autentication.Dto
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O Email deve ser válido.")]
        [StringLength(255, ErrorMessage = "O Email deve ter no máximo 255 caracteres.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória.")]
        [StringLength(255, ErrorMessage = "A Senha deve ter no máximo 255 caracteres.")]
        public required string Senha { get; set; }
    }
}
