using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Entities
{
    public class Mensagem
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string Disciplina { get; set; }
        public string Link { get; set; }
        public DateTime DataDeGeracao { get; set; }
        public bool Visualizado { get; set; }
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
