using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using Erratas.Domain.Interfaces.Services;
using Erratas.Domain.Validations.Errata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Erratas.Domain.Services
{
    public class ErrataService : IErrataService
    {
       
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IInstitutoRepository _institutoRepository;
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly ICursoDisciplinaRepository _cursoDisciplinaRepository;
        private readonly ICursoRepository _cursoRepository;
        private readonly IErrataRepository _errataRepository;
        private readonly IErrataImagemRepository _errataImagemRepository;
        private readonly IErrataCursoRepository _errataCursoRepository;
        private readonly IMotivoErrataRepository _motivoErrataRepository;
        private readonly IUnidadeRepository _unidadeRepository;  
        public ErrataService(IUsuarioRepository usuarioRepository,
            IInstitutoRepository institutoRepository,
            IDisciplinaRepository disciplinaRepository,
            ICursoRepository cursoRepository,
            IErrataRepository errataRepository,
            ICursoDisciplinaRepository cursoDisciplinaRepository,
            IErrataImagemRepository errataImagemRepository,
            IErrataCursoRepository errataCursoRepository,
             IMotivoErrataRepository motivoErrataRepository,
            IUnidadeRepository unidadeRepository)
        {
            _usuarioRepository = usuarioRepository;
            _institutoRepository = institutoRepository;
            _disciplinaRepository = disciplinaRepository;
            _cursoRepository = cursoRepository;
            _errataRepository = errataRepository;
            _errataImagemRepository = errataImagemRepository;
            _cursoDisciplinaRepository = cursoDisciplinaRepository;
            _errataCursoRepository = errataCursoRepository;
            _motivoErrataRepository = motivoErrataRepository;
            _unidadeRepository = unidadeRepository;
        }
        public Errata Cadastrar(Errata errata)
        {
            if (!errata.EhValido())
                return errata;

            errata.ValidationResult = new CadastrarErrataValidator(
                                                _usuarioRepository,
                                                _institutoRepository,
                                                _disciplinaRepository,
                                                _cursoRepository,
                                                _motivoErrataRepository,
                                                _unidadeRepository).Validate(errata);

            if (!errata.ValidationResult.IsValid)
                return errata;

            errata = _errataRepository.Cadastrar(errata);

            if (!errata.ValidationResult.IsValid)
                return errata;

            // this.SalvarImagens(errata);

            return errata;
        }

        private bool SalvarImagens(Errata errata)
        {
            var i = 0;
            var arquivos = HttpContext.Current.Request.Files;
            if (errata.ImagensErrata == null)
                return true;

            foreach (var item in errata.ImagensErrata)
            {
                arquivos[i].SaveAs(HttpContext.Current.Server.MapPath("~/") + "\\" + item.CaminhoImagem);
                i++;
            }

            return true;
        }

        public Errata Atualizar(Errata errata)
        {
            if (!errata.EhValido())
                return errata;

            errata.ValidationResult = new AtualizarErrataValidator(
                                             _usuarioRepository, 
                                             _institutoRepository,
                                             _disciplinaRepository, 
                                             _cursoRepository, 
                                             _errataRepository,
                                             _motivoErrataRepository,
                                             _unidadeRepository).Validate(errata);

            if (!errata.ValidationResult.IsValid)
                return errata;

            var aux = _errataRepository.ObterPorId(errata.Id);
            var cursos = aux.ErrataCursos;

            _errataRepository.Detach(aux);
            
            if (!errata.ValidationResult.IsValid)
                return errata;

            foreach (var item in errata.ImagensErrata)
                _errataImagemRepository.Cadastrar(item);

            this.DeletarCursos(cursos); 
            this.DeletarImagensErrata();
            // this.SalvarImagens(errata);

            errata = _errataRepository.Atualizar(errata);

            return errata;
        }

        private void DeletarCursos(ICollection<ErrataCurso> cursos)
        {
            foreach (var item in cursos)
            {
                _errataCursoRepository.Deletar(item.Id);
            }
        }

        private void DeletarImagensErrata()
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.Params["RemoverImagensErrata"]))
                return;

            var imagens = HttpContext.Current.Request.Params["RemoverImagensErrata"].Split(',');  
            foreach (var item in imagens)
            {
                var id = Guid.Parse(item);
                if (_errataImagemRepository.ObterPorId(id) != null)
                    _errataImagemRepository.Deletar(id);
            }
        }
    }
}
