using System.ComponentModel.DataAnnotations;

namespace GestorMultiPessoas.Autentication.Dto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "O Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O Email deve ser válido.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória.")]
        public required string Senha { get; set; }
    }
}
