using GestorMultiPessoas.Model.Cadastro;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestorMultiPessoas.Model
{
    public class Desligamento
    {
        [Key]
        public Guid DesligamentoId { get; set; } = Guid.NewGuid();

        [Required]
        public Guid FuncionarioId { get; set; }

        [ForeignKey("FuncionarioId")]
        public Funcionario Funcionario { get; set; } = null!;

        public DateTime DataDesligamento { get; set; }
        public string Motivo { get; set; } = string.Empty; // Pedido de demissão, Justa causa, Acordo, Aposentadoria
        public string TipoAviso { get; set; } = string.Empty; // Trabalhado, Indenizado
        public decimal ValorRescisao { get; set; }
    }
}
