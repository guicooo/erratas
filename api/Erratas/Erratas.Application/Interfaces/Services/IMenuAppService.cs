using Erratas.Application.Models.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Interfaces.Services
{
    public interface IMenuAppService
    {
        MenuModel Listar();
    }
}
