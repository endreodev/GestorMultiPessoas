using GestorMultiPessoas.Model.Cadastro;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestorMultiPessoas.Model
{
    public class IntegracaoContabil
    {
        [Key]
        public Guid IntegracaoContabilId { get; set; } = Guid.NewGuid();

        [Required]
        public Guid FuncionarioId { get; set; }

        [ForeignKey("FuncionarioId")]
        public Funcionario Funcionario { get; set; } = null!;

        public decimal FGTS { get; set; }
        public decimal INSS { get; set; }
        public decimal IRRF { get; set; }
        public string HistoricoVerbas { get; set; } = string.Empty; // JSON com detalhes de pagamentos
    }
}
