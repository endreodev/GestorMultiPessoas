using System.ComponentModel.DataAnnotations;

namespace GestorMultiPessoas.Autentication.Model
{
    public class Restricoes
    {
        [Key]
        public Guid RestricaoId { get; set; } = Guid.NewGuid();

    }
}
