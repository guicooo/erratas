using Erratas.Application.Models.Disciplinas;
using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Interfaces.Services
{
    public interface IDisciplinaAppService
    {
        IEnumerable<Disciplina> Listar();
        ObterDisciplinaModel Obter(string Id);
        Disciplina Cadastrar(DisciplinaModel disciplinaModel);
        Disciplina Atualizar(string Id, AtualizarDisciplinaModel atualizarDisciplinaModel);
        bool Deletar(string Id);
    }
}
