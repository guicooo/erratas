using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Erratas.Domain.Validations
{
    public class NovaSenhaValidator : AbstractValidator<Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public NovaSenhaValidator(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;           

            RuleFor(x => x.Email).Must(SerEmailValido).WithMessage("E-mail é inválido");
            RuleFor(x => x.Senha).Must(SerSenhaValida).WithMessage("Senha não é válida");
            RuleFor(x => x.Email).Must(SerNull).WithMessage("Usuário possui senha ativa");                 
        }

        private bool SerEmailValido(string Email)
        {
            return _usuarioRepository.ObterPorEmail(Email) != null;
        }

        private bool SerNull(string Email)
        {
            var usuario = _usuarioRepository.ObterPorEmail(Email);
            if(usuario == null)
                return false;

            return usuario.Senha == null ? true : false;
        }

        private bool SerSenhaValida(string Senha)
        {
            return Regex.IsMatch(Senha, "^[0-9a-fA-F]{32}$", RegexOptions.Compiled);
        }

    }
}
