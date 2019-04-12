using Erratas.Application.Models.Cursos;
using Erratas.Application.Models.Disciplinas;
using Erratas.Application.Models.Usuarios;
using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Models.Erratas
{
    public class ObterErrataModel
    {
        public ObterErrataModel()
        {
            ImagensErrata = new List<ImagemErrataModel>();
            ErrataCursos = new List<CursoModel>();
        }
        public Guid Id { get; set; }
        public ICollection<ImagemErrataModel> ImagensErrata { get; set; }
        public Instituto Instituto { get; set; }
        public MotivoErrata MotivoErrata { get; set; }
        public Unidade Unidade { get; set; }
        public ObterUsuarioModel ResponsavelInsercao { get; set; }
        public ObterUsuarioModel ResponsavelRevisao { get; set; }
        public string Descricao { get; set; }
        public string Professor { get; set; }
        public bool AvisoPostado { get; set; }
        public DateTime DataDeSolicitacao { get; set; }
        public string CodigoModelo { get; set; }
        public string CodigoOferta { get; set; }
        public ICollection<CursoModel> ErrataCursos { get; set; }
        public Disciplina Disciplina { get; set; }
        public Item Item { get; set; }

    }
}
