using System.ComponentModel.DataAnnotations;

namespace GestorMultiPessoas.Autentication.Dto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "O Email � obrigat�rio.")]
        [EmailAddress(ErrorMessage = "O Email deve ser v�lido.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "A Senha � obrigat�ria.")]
        public required string Senha { get; set; }
    }
}
