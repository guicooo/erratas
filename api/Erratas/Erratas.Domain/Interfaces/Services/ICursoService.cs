using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Interfaces.Services
{
    public interface ICursoService
    {
        Curso Cadastrar(Curso curso);
        Curso Atualizar(Curso curso);
        bool Deletar(string Id);
    }
}
