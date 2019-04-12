using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using Erratas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Services
{
    public class MensagemService : IMensagemService
    {
        private readonly IMensagemRepository _mensagemRepository;
        public MensagemService(IMensagemRepository mensagemRepository)
        {
            _mensagemRepository = mensagemRepository;
        }
        public bool GravarMensagem(Mensagem mensagem)
        {
            _mensagemRepository.Cadastrar(mensagem);
            return true;
        }


        public bool Atualizar(Mensagem mensagem)
        {
            _mensagemRepository.Atualizar(mensagem);
            return true;
        }
    }
}
