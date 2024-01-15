using Dominio.Interfaces.ISistemaFinanceiro;
using Entities.Entidades;
using InfraEstrutura.Configuracao;
using InfraEstrutura.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace InfraEstrutura.Repositorio
{
    public class RepositorioSistemaFinanceiro : RepositoryGenerics<SistemaFinanceiro>, InterfaceSistemaFinanceiro
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositorioSistemaFinanceiro()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<SistemaFinanceiro>> ListarSistemasUsuario(string emailUsuario)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            { 
                return await
                    (from s in banco.SistemaFinanceiro
                     join us in banco.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                     where us.EmailUsuario.Equals(emailUsuario)
                     select s).AsNoTracking().ToListAsync();
            }
        }
    }
}
