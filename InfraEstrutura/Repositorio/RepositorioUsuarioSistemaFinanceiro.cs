using Dominio.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entidades;
using InfraEstrutura.Repositorio.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraEstrutura.Repositorio
{
    public class RepositorioUsuarioSistemaFinanceiro : RepositoryGenerics<UsuarioSistemaFinanceiro>, 
        InterfaceUsuarioSistemaFinanceiro
    {
    }
}
