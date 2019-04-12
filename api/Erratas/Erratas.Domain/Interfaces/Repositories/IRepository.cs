using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Interfaces.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        T ObterPorId(Guid Id);
        IEnumerable<T> Listar();
        T Cadastrar(T Entity);
        int Salvar();
        T Atualizar(T Entity);
        bool Deletar(Guid Id);
        void Detach(T Entity);
    }
}
