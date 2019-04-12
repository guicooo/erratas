using Erratas.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Erratas.Domain.Validations.Errata
{
    public class ErrataValidator : AbstractValidator<Entities.Errata>
    {
        public ErrataValidator()
        {                    
            RuleFor(x => x.ImagensErrata).Must(SerImagem).WithMessage("Arquivos não são imagens");
            RuleFor(x => x.MotivoErrataId).Must(TerMotivoErrataId).WithMessage("Motivo errata é obrigatório");
            RuleFor(x => x.DisciplinaId).Must(TerDisciplinaId).WithMessage("Disciplina é obrigatório");
            RuleFor(x => x.CodigoModelo).Must(TerCodigoModelo).WithMessage("Codigo modelo é obrigatório");
            RuleFor(x => x.ResponsavelInsercaoId).Must(TerResponsavelInsercaoId).WithMessage("Responsavel inserção é obrigatório");
            RuleFor(x => x.ResponsavelRevisaoId).Must(TerResponsavelRevisaoId).WithMessage("Responsavel revisão é obrigatório");
            RuleFor(x => x.InstitutoId).Must(TerInstitutoId).WithMessage("Instituto é obrigatório");
            RuleFor(x => x.UnidadeId).Must(TerUnidadeId).WithMessage("Unidade é obrigatório");
            RuleFor(x => x.Professor).Must(TerProfessor).WithMessage("Professor é obrigatório");
            RuleFor(x => x.DataDeSolicitacao).Must(SerDataValida).WithMessage("Data inválida");
        }
        private bool SerImagem(ICollection<ImagemErrata> ImagensErrata)
        {
            if (ImagensErrata == null)
                return true;

            foreach(var item in ImagensErrata)
            {
                if(!Regex.IsMatch(item.CaminhoImagem.ToLower(), @"^.*\.(jpg|jpge|png)$"))
                    return false;
            }

            return true;
        }

        private bool SerDataValida(DateTime data)
        {
            return data < DateTime.Now && data != DateTime.MinValue;
        }

        private bool TerMotivoErrataId(Guid MotivoErrataId)
        {
            if (Guid.Empty != MotivoErrataId)
                return true;
            
             return false;
        }

        private bool TerDisciplinaId(string DisciplinaId)
        {
            if (!string.IsNullOrEmpty(DisciplinaId))
                return true;
           
            return false;
        }
        private bool TerCodigoModelo(string CodigoModelo)
        {
            if (!string.IsNullOrEmpty(CodigoModelo))
                return true;
          
           return false;
        }

        private bool TerResponsavelInsercaoId(Guid ResponsavelInsercaoId)
        {
            if (Guid.Empty != ResponsavelInsercaoId)
                return true;

            return false;
        }

        private bool TerResponsavelRevisaoId(Guid ResponsavelRevisaoId)
        {
            if (Guid.Empty != ResponsavelRevisaoId)
                return true;

            return false;
        }

        private bool TerInstitutoId(Guid InstitutoId)
        {
            if (Guid.Empty != InstitutoId)
                return true;

            return false;
        }

        private bool TerUnidadeId(Guid UnidadeId)
        {
            if (Guid.Empty != UnidadeId)
                return true;

            return false;
        }

        private bool TerProfessor(string Professor)
        {
            if (!string.IsNullOrEmpty(Professor))
                return true;

            return false;
        }
    }
}
