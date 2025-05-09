using GestorMultiPessoas.Autentication.Enums;
using System.ComponentModel.DataAnnotations;

namespace GestorMultiPessoas.Autentication.Model
{


    public class Usuario
    {
        [Key]
        public Guid UsuarioId { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O campo Sobrenome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Sobrenome deve ter no máximo 100 caracteres.")]
        public required string Sobrenome { get; set; }

        [Required(ErrorMessage = "O campo Usuário é obrigatório.")]
        [StringLength(50, ErrorMessage = "O Usuário deve ter no máximo 50 caracteres.")]
        public required string UsuarioNome { get; set; } // Renomeado para evitar conflito com palavra reservada

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [StringLength(255, ErrorMessage = "A Senha deve ter no máximo 255 caracteres.")]
        public required string Senha { get; set; } // Armazena hash da senha

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O Email deve ser válido.")]
        [StringLength(255, ErrorMessage = "O Email deve ter no máximo 255 caracteres.")]
        public required string Email { get; set; }

        [StringLength(15, ErrorMessage = "O Celular deve ter no máximo 15 caracteres.")]
        [RegularExpression(@"^\+?\d{10,15}$", ErrorMessage = "O Celular deve ser válido (ex.: +5511999999999).")]
        public string? Celular { get; set; }

        [Required(ErrorMessage = "O campo Perfil é obrigatório.")]
        public EnunsAutentication.PerfilUsuario Perfil { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
