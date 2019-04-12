using Erratas.Application.Models;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace Erratas.Application.Adapters
{
    public static class MensagemAdapter
    {
        public static IList<MensagemModel> RetornarMensagensFluent(ValidationResult validation)
        {
            var mensagens = new List<MensagemModel>();
            foreach (var erro in validation.Errors)
            {
                mensagens.Add(new MensagemModel
                {
                    Mensagem = erro.ErrorMessage
                });
            }

            return mensagens;
        }

        public static IList<MensagemModel> RetornarMensagensModelState(ICollection<ModelState> validation)
        {
            var mensagens = new List<MensagemModel>();
            foreach (var item in validation)
            {
                foreach (var erros in item.Errors)
                {
                    mensagens.Add(new MensagemModel
                    {
                        Mensagem = !string.IsNullOrEmpty(erros.ErrorMessage) ? erros.ErrorMessage : "Ocorreu um erro não esperado"
                    });
                }

            }

            return mensagens;
        }
    }
}
