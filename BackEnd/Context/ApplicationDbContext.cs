using GestorMultiPessoas.Model.Acessos;
using GestorMultiPessoas.Model.Cadastro;
using Microsoft.EntityFrameworkCore;


namespace GestorMultiPessoas.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        //public required DbSet<DicTabela> DicTabelas { get; set; }
        //public required DbSet<Dicusuario> Dicusuarios { get; set; }
        //public required DbSet<DicMascara> DicMascaras { get; set; }
        //public required DbSet<DicLayoutUI> DicLayouts { get; set; }
        
        public required DbSet<Usuario> Usuarios { get; set; }
        public required DbSet<Empresa> Empresas { get; set; }
        public required DbSet<Funcionario> Funcionarios { get; set; }
        public required DbSet<Salario> Salarios { get; set; }
        public required DbSet<Beneficio> Beneficios { get; set; }








        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>()
               .HasOne(e => e.EmpresaIdPai)  // Relacionamento: Uma empresa tem um pai
               .WithMany(e => e.Filiais) // Um pai pode ter várias filiais
               .HasForeignKey(e => e.EmpresaIdPaiGuiu) // FK é PaiGuiu
               .OnDelete(DeleteBehavior.Restrict); // Evita exclusão em cascata

            modelBuilder.Entity<Empresa>()
            .HasMany(e => e.Funcionarios)
            .WithOne(f => f.Empresa)
            .HasForeignKey(f => f.EmpresaId);

            modelBuilder.Entity<Funcionario>()
                .HasOne(f => f.Empresa)
                .WithMany(e => e.Funcionarios)
                .HasForeignKey(f => f.EmpresaId);

            base.OnModelCreating(modelBuilder);
        }
    }
}