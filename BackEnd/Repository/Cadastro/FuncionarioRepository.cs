using GestorMultiPessoas.Context;
using GestorMultiPessoas.Interface;
using GestorMultiPessoas.Model.Cadastro;

namespace GestorMultiPessoas.Repository.Cadastro
{
    public interface IFuncionarioRepository : IRepository<Funcionario> { }

    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(ApplicationDbContext context) : base(context) { }
    }
}
