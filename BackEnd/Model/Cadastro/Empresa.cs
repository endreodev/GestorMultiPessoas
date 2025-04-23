using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestorMultiPessoas.Model.Cadastro
{
    public class Empresa
    {
        // Constantes para o campo TIPO
        public const string TIPO_GRUPO = "G";
        public const string TIPO_EMPRESA = "E";
        public const string TIPO_FILIAL = "F";
        private static readonly List<Empresa> empresas = [];

        [Key]
        public Guid EmpresaId { get; set; } = Guid.NewGuid();

        // 🔹 Chave estrangeira para empresa pai deve ser do mesmo tipo que CODEMP (Guid)
        [ForeignKey("Pai")]
        public Guid? EmpresaIdPaiGuiu { get; set; }

        // 🔹 Propriedade de navegação para empresa pai
        public Empresa? EmpresaIdPai { get; set; }

        [Required(ErrorMessage = "O campo Tipo é obrigatório.")]
        [StringLength(1, ErrorMessage = "O campo Tipo deve ter 1 caractere.")]
        [RegularExpression("^[GEF]$", ErrorMessage = "O campo Tipo deve ser 'G' (Grupo), 'E' (Empresa) ou 'F' (Filial).")]
        public required string Tipo { get; set; }

        [Required(ErrorMessage = "O campo CNPJ é obrigatório.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O campo CNPJ deve ter 14 dígitos.")]
        public required string Cnpj { get; set; }

        [Required(ErrorMessage = "O campo Razão Social é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Razão Social deve ter no máximo 100 caracteres.")]
        public required string RazaoSocial { get; set; }

        [StringLength(100, ErrorMessage = "O campo Nome Fantasia deve ter no máximo 100 caracteres.")]
        public string? NomeFantasia { get; set; }

        [StringLength(20, ErrorMessage = "O campo Inscrição Estadual deve ter no máximo 20 caracteres.")]
        public string? InscricaoEstadual { get; set; }

        [StringLength(20, ErrorMessage = "O campo Inscrição Municipal deve ter no máximo 20 caracteres.")]
        public string? InscricaoMunicipal { get; set; }

        [Required(ErrorMessage = "O campo Cep é obrigatório.")]
        [StringLength(8, ErrorMessage = "O campo Cep deve ser preenchido com 8 dígitos.")]
        public required string Cep { get; set; }

        [Required(ErrorMessage = "O campo Endereço é obrigatório.")]
        [StringLength(200, ErrorMessage = "O campo Endereço deve ter no máximo 200 caracteres.")]
        public required string Endereco { get; set; }

        [Required(ErrorMessage = "O campo Número é obrigatório.")]
        [StringLength(10, ErrorMessage = "O campo Número deve ter no máximo 10 caracteres.")]
        public required string Numero { get; set; }

        [Required(ErrorMessage = "O campo Complemento é obrigatório.")]
        [StringLength(30, ErrorMessage = "O campo Complemento deve ter no máximo 30 caracteres.")]
        public required string Complemento { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        [StringLength(20, ErrorMessage = "O campo Telefone deve ter no máximo 20 caracteres.")]
        public string? Telefone { get; set; }

        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo E-mail deve ser um endereço de e-mail válido.")]
        public string? Email { get; set; }

        // 🔹 Relacionamento com filiais
        public ICollection<Empresa> Filiais { get; set; } = empresas;
        // Relacionamento 1:N (Uma empresa pode ter vários funcionários)
        public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
    }
}
