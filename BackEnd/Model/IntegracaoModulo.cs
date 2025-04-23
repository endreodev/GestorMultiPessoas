using GestorMultiPessoas.Model.Cadastro;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestorMultiPessoas.Model
{
    public class IntegracaoModulo
    {
        [Key]
        public Guid IntegracaoModuloId { get; set; } = Guid.NewGuid();

        [Required]
        public Guid FuncionarioId { get; set; }

        [ForeignKey("FuncionarioId")]
        public Funcionario Funcionario { get; set; } = null!;

        public string Modulo { get; set; } = string.Empty; // ERP, Folha de Pagamento, Financeiro
        public string DadosIntegracao { get; set; } = string.Empty; // JSON com os dados necessários para integração
    }
}
