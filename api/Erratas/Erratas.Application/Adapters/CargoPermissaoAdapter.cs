using Erratas.Application.Models;
using Erratas.Application.Models.Modulo;
using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Adapters
{
    public class CargoPermissaoAdapter
    {
        public ObterCargoModel CargoPermissaoParaObterCargoModel(IEnumerable<CargoPermissao> permissoes)
        {
            if (permissoes.Count() == 0)
                return new ObterCargoModel();

            var cargo = new ObterCargoModel()
            {
                Nome = permissoes.First().Cargo.Nome,
                Id = permissoes.First().Cargo.Id.ToString(),
                Modulos = new List<ModuloModel>()       
            };
       
            foreach (var item in permissoes)
            {
                var aux = new PermissaoModel()
                {
                    Abreviacao = item.Permissao.Abreviacao,
                    Autorizado = item.Autorizado,
                    Descricao = item.Permissao.Descricao,
                    Id = item.Permissao.Id.ToString()
                };

                var modulo = new ModuloModel()
                {
                    Permissoes = new List<PermissaoModel>() { aux },                    
                    Id = item.Permissao.Modulo.Id,
                    Nome = item.Permissao.Modulo.Nome
                };
              
                var moduloAntigo = cargo.Modulos.Where(x => x.Nome == modulo.Nome).FirstOrDefault();

                if (moduloAntigo != null)
                    moduloAntigo.Permissoes.Add(aux);
                else
                    cargo.Modulos.Add(modulo);
            }

            cargo.Modulos = cargo.Modulos.OrderBy(x => x.Nome).ToList();

            return cargo;
        }
    }
}

