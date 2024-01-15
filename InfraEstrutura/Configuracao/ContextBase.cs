using Entities.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfraEstrutura.Configuracao
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<SistemaFinanceiro> SistemaFinanceiro { get; set; }

        public DbSet<UsuarioSistemaFinanceiro> UsuarioSistemaFinanceiro { get; set; }

        public DbSet<Categoria> Categoria {  get; set; }

        public DbSet<Despesa> Despesa { get; set; }

        //Configuração da string de conexão.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }

        }

        //Mapear a tabela
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }
        
        public string ObterStringConexao()
        {

            return "Data Source=DESKTOP-30B570N\\SQLEXPRESS;Initial Catalog=FINANCEIRO_2023;Integrated Security=True";
        }
    }
}
