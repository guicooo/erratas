using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Erratas.Application.Models.Erratas
{
    public class ErrataModel
    {
        public ErrataModel()
        {
            ImagensErrata = new List<string>();
        }
        public Guid Id { get; set; }
        public Guid MotivoErrataId { get; set; }     
        public string DisciplinaId { get; set; }
        public virtual ICollection<string> ErrataCursos { get; set; }
        public string CodigoModelo { get; set; }
        public string CodigoOferta { get; set; }
        public DateTime DataDeSolicitacao { get; set; }
        public Guid ResponsavelInsercaoId { get; set; }
        public Guid ResponsavelRevisaoId { get; set; }    
        public bool AvisoPostado { get; set; }
        public Guid InstitutoId { get; set; }      
        public Guid UnidadeId { get; set; }
        public string Descricao { get; set; }
        public string Professor { get; set; }
        public virtual ICollection<string> ImagensErrata { get; set; }        
    }
}
