using GestorMultiPessoas.Context;
using GestorMultiPessoas.Interface;
using GestorMultiPessoas.Model.Cadastro;

namespace GestorMultiPessoas.Repository.Cadastro
{
    public interface ISalarioRepository : IRepository<Salario> { }

    public class SalarioRepository : Repository<Salario>, ISalarioRepository
    {
        public SalarioRepository(ApplicationDbContext context) : base(context) { }
    }
}
