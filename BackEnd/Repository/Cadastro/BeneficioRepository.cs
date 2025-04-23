using GestorMultiPessoas.Context;
using GestorMultiPessoas.Interface;
using GestorMultiPessoas.Model.Cadastro;

namespace GestorMultiPessoas.Repository.Cadastro
{
    public interface IBeneficioRepository : IRepository<Beneficio> { }

    public class BeneficioRepository : Repository<Beneficio>, IBeneficioRepository
    {
        public BeneficioRepository(ApplicationDbContext context) : base(context) { }
    }

}
