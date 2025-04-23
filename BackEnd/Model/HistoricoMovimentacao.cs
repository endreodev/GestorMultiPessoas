using GestorMultiPessoas.Model.Cadastro;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestorMultiPessoas.Model
{
    public class HistoricoMovimentacao
    {
        [Key]
        public Guid HistoricoMovimentacaoId { get; set; } = Guid.NewGuid();

        [Required]
        public Guid FuncionarioId { get; set; }

        [ForeignKey("FuncionarioId")]
        public Funcionario Funcionario { get; set; } = null!;

        public DateTime DataMovimentacao { get; set; }
        public string TipoMovimentacao { get; set; } = string.Empty; // Promoção, Transferência, Mudança de Cargo
        public string Descricao { get; set; } = string.Empty;
    }
}
