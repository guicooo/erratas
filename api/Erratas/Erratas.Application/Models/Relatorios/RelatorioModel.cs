using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Models.Relatorios
{
    public class RelatorioModel
    {
        public RelatorioModel()
        {
            Departamento = new List<RelatorioDepartamentoModel>();
            Usuario = new List<RelatorioUsuarioModel>();
        }
        public string Tipo { get; set; }
        public List<RelatorioDepartamentoModel> Departamento { get; set; }
        public List<RelatorioUsuarioModel> Usuario { get; set; }
    }
}
