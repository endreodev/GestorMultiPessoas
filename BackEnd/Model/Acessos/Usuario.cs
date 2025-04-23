using System.ComponentModel.DataAnnotations;

namespace GestorMultiPessoas.Model.Acessos
{
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string SenhaHash { get; set; } = string.Empty; // Senha será armazenada com hash

    }
}
