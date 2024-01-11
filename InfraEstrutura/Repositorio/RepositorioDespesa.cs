using Dominio.Interfaces.IDespesa;
using Entities.Entidades;
using InfraEstrutura.Repositorio.Generics;

namespace InfraEstrutura.Repositorio
{

    public class RepositorioDespesa : RepositoryGenerics<Despesa>, InterfaceDespesa
    {   
    }
}
