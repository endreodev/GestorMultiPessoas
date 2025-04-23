using GestorMultiPessoas.Model.Cadastro;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorMultiPessoas.Model.Cadastro
{
    public class Colaborador
    {
        [Key]
        public Guid ColaboradorId { get; set; } = Guid.NewGuid();

        // Relacionamento com Empresa
        [Required]
        public Guid EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string Matricula { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string Nome { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Apelido { get; set; } = string.Empty;

        public DateTime DataNascimento { get; set; }

        [Required]
        [MaxLength(14)]
        public string CPF { get; set; } = string.Empty;

        [MaxLength(20)]
        public string RG { get; set; } = string.Empty;

        [MaxLength(10)]
        public string Sexo { get; set; } = string.Empty;

        [MaxLength(20)]
        public string EstadoCivil { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Telefone { get; set; } = string.Empty;

        [MaxLength(250)]
        public string Endereco { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Bairro { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Cidade { get; set; } = string.Empty;

        [MaxLength(2)]
        public string Estado { get; set; } = string.Empty;

        [MaxLength(10)]
        public string CEP { get; set; } = string.Empty;

        public DateTime DataAdmissao { get; set; }

        [MaxLength(100)]
        public string Cargo { get; set; } = string.Empty;

        [MaxLength(50)]
        public string CentroCusto { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Departamento { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Funcao { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Situacao { get; set; } = string.Empty; // Ativo, Inativo

        [MaxLength(20)]
        public string TipoVinculo { get; set; } = string.Empty; // CLT, PJ, Estágio

        [MaxLength(20)]
        public string Supervisor { get; set; } = string.Empty;
    }
}