using Erratas.Application.Models.Usuarios;
using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Models.Logs
{
    public class ObterLogModel
    {
        public ObterLogModel()
        {
            Usuario = new ObterUsuarioModel();
        }
        public Guid Id { get; set; }
        public string Verbo { get; set; }
        public ObterUsuarioModel Usuario { get; set; }
        public string Status { get; set; }
        public string Acao { get; set; }
        public string Controller { get; set; }
        public string Url { get; set; }
        public DateTime DataDeGravacao { get; set; }
        public string Retorno { get; set; }
    }
}
