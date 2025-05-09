using System.ComponentModel.DataAnnotations;

namespace GestorMultiPessoas.Autentication.Dto
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "O Nome � obrigat�rio.")]
        [StringLength(100, ErrorMessage = "O Nome deve ter no m�ximo 100 caracteres.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O Email � obrigat�rio.")]
        [EmailAddress(ErrorMessage = "O Email deve ser v�lido.")]
        [StringLength(255, ErrorMessage = "O Email deve ter no m�ximo 255 caracteres.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "A Senha � obrigat�ria.")]
        [StringLength(255, ErrorMessage = "A Senha deve ter no m�ximo 255 caracteres.")]
        public required string Senha { get; set; }
    }
}
