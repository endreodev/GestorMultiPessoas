using GestorMultiPessoas.Context;
using GestorMultiPessoas.Model.Cadastro;
using Microsoft.EntityFrameworkCore;

namespace GestorMultiPessoas.Repository.Cadastro
{
    public class EmpresaRepository(ApplicationDbContext context)
    {
        private readonly ApplicationDbContext _context = context;

        // Retorna todas as empresas
        public async Task<List<Empresa>> GetAllAsync()
        {
            return await _context.Empresas
                .Include(e => e.Filiais)
                .Include(e => e.EmpresaIdPai)
                .ToListAsync();
        }

        // Retorna uma empresa pelo ID
        public async Task<Empresa?> GetByIdAsync(Guid id)
        {
            return await _context.Empresas
                .Include(e => e.Filiais)
                .Include(e => e.EmpresaIdPai)
                .FirstOrDefaultAsync(e => e.EmpresaId == id);
        }

        // Adiciona uma nova empresa
        public async Task AddAsync(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();
        }

        // Atualiza uma empresa existente
        public async Task UpdateAsync(Empresa empresa)
        {
            _context.Empresas.Update(empresa);
            await _context.SaveChangesAsync();
        }

        // Remove uma empresa pelo ID
        public async Task DeleteAsync(Guid id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa != null)
            {
                _context.Empresas.Remove(empresa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
