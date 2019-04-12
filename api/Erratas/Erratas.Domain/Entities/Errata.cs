using Erratas.Domain.Validations.Errata;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Erratas.Domain.Entities
{
    public class Errata
    {
        public Errata()
        {
            ImagensErrata = new List<ImagemErrata>();
            ErrataCursos = new List<ErrataCurso>();
        }
        public Guid Id { get; set; }
        public Guid MotivoErrataId { get; set; }
        public virtual MotivoErrata MotivoErrata { get; set; }
        public string DisciplinaId { get; set; }
        public virtual Disciplina Disciplina { get; set; }
        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }
        public virtual ICollection<ErrataCurso> ErrataCursos { get; set; }
        public string CodigoModelo { get; set; }
        public string CodigoOferta { get; set; }
        public DateTime DataDeSolicitacao { get; set; }
        public Guid ResponsavelInsercaoId { get; set; }      
        public Guid ResponsavelRevisaoId { get; set; }
        public virtual Usuario ResponsavelInsercao { get; set; }
        public virtual Usuario ResponsavelRevisao { get; set; }
        public bool AvisoPostado { get; set; }
        public Guid InstitutoId { get; set; }
        public virtual Instituto Instituto { get; set; }
        public Guid UnidadeId { get; set; }
        public virtual Unidade Unidade { get; set; }
        public string Descricao { get; set; }
        public string Professor { get; set; }
        public virtual ICollection<ImagemErrata> ImagensErrata { get; set; }
        public virtual ValidationResult ValidationResult { get; set; }       

        public bool EhValido()
        {
            ValidationResult = new ErrataValidator().Validate(this);
            return ValidationResult.IsValid;
        }
       
    }
}
