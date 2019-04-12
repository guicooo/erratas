using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Interfaces.Services
{
    public interface IMensagemAppService 
    {
        bool GravarMensagem(IEnumerable<string> Ids, string Descricao, string Disciplina, string Link);    
        IEnumerable<Mensagem> Listar();
        bool Atualizar(Guid Id);
        bool AtualizarTodas();
    }
}
