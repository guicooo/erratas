using Erratas.Application.Models.Menu;
using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Adapters
{
    public class MenuAdapter
    {
        public MenuModel CargoPermissaoParaMenuModel(IEnumerable<CargoPermissao> cargoPermissoes)
        {
            var menu = new MenuModel()
            {
                Modulos = new List<ModuloMenuModel>()
            };
          
            foreach (var item in cargoPermissoes)
            {
                
                var aux = new PermissaoMenuModel()
                {                   
                    Autorizado = item.Autorizado,
                    Nome = item.Permissao.Descricao,
                    Id = item.Permissao.Id
                };

                var modulo = new ModuloMenuModel()
                {
                    Permissoes = new List<PermissaoMenuModel>() { aux },                    
                    Nome = item.Permissao.Modulo.Nome
                };

                var moduloAntigo = menu.Modulos.Where(x => x.Nome == modulo.Nome).FirstOrDefault();

                if (moduloAntigo != null)
                    moduloAntigo.Permissoes.Add(aux);
                else
                    menu.Modulos.Add(modulo);
            }

            foreach(var modulos in menu.Modulos)
            {
                modulos.Autorizado = modulos.Permissoes.Any(x => x.Autorizado == true);
            }

            return menu;
        }
    }
}
