using GestorMultiPessoas.Model.Cadastro;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestorMultiPessoas.Model
{
    public class PontoFerias
    {
        [Key]
        public Guid PontoFeriasId { get; set; } = Guid.NewGuid();

        [Required]
        public Guid FuncionarioId { get; set; }

        [ForeignKey("FuncionarioId")]
        public Funcionario Funcionario { get; set; } = null!;

        public DateTime DataRegistro { get; set; }
        public int HorasTrabalhadas { get; set; }
        public int HorasExtras { get; set; }
        public bool Afastado { get; set; } = false;

        public DateTime? DataInicioFerias { get; set; }
        public DateTime? DataFimFerias { get; set; }
        public int DiasFerias { get; set; }
    }
}
