using GestorMultiPessoas.Context;
using GestorMultiPessoas.Model.Acessos;
using Microsoft.EntityFrameworkCore;

namespace GestorMultiPessoas.Repository.Cadastro
{
    public class UsuarioRepository(ApplicationDbContext context)
    {

        // 🔹 Retorna todos os usuários
        public async Task<List<Usuario>> GetAllAsync()
        {
            return await context.Usuarios.ToListAsync();
        }

        // 🔹 Retorna um usuário pelo ID
        public async Task<Usuario?> GetByIdAsync(Guid id)
        {
            return await context.Usuarios.FindAsync(id);
        }

        // 🔹 Retorna um usuário pelo email
        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        // 🔹 Adiciona um novo usuário (com hash de senha)
        public async Task AddAsync(Usuario usuario)
        {
            usuario.SenhaHash = BCrypt.Net.BCrypt.HashPassword(usuario.SenhaHash); // Hash da senha
            context.Usuarios.Add(usuario);
            await context.SaveChangesAsync();
        }

        // 🔹 Atualiza um usuário
        public async Task UpdateAsync(Usuario usuario)
        {
            context.Usuarios.Update(usuario);
            await context.SaveChangesAsync();
        }

        // 🔹 Remove um usuário pelo ID
        public async Task DeleteAsync(Guid id)
        {
            var usuario = await context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                context.Usuarios.Remove(usuario);
                await context.SaveChangesAsync();
            }
        }
    }
}
