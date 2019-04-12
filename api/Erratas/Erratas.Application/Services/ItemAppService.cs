using Erratas.Application.Interfaces.Services;
using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Services
{
    public class ItemAppService : IItemAppService
    {
        private readonly IItemRepository _itemRepository;
        public ItemAppService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IEnumerable<Item> Listar()
        {
            return _itemRepository.Listar();
        }
    }
}
