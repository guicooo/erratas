using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using Erratas.Domain.Interfaces.Services;
using ExcelDataReader;
using ExcelDataReader.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Erratas.Domain.Services
{
    public class ExtrapolacaoService : IExtrapolacaoService
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly ICursoDisciplinaRepository _cursoDisciplinaRepository;
        public ExtrapolacaoService(ICursoRepository cursoRepository, IDisciplinaRepository disciplinaRepository, ICursoDisciplinaRepository cursoDisciplinaRepository)
        {
            _cursoRepository = cursoRepository;
            _disciplinaRepository = disciplinaRepository;
            _cursoDisciplinaRepository = cursoDisciplinaRepository;
        }
        public bool ExtrapolarGrade(HttpPostedFile arquivo)
        {
            var caminho = Path.Combine(HttpContext.Current.Server.MapPath("~/Arquivos"), Guid.NewGuid().ToString() + arquivo.FileName);
            arquivo.SaveAs(caminho);

            var cursos = new List<Curso>();
            var disciplinas = new List<Disciplina>();
            var cursosDisciplinas = new List<CursoDisciplina>();

            LerExcel(caminho, ref cursos, ref disciplinas, ref cursosDisciplinas);
            GravarCursos(cursos);
            GravarDisciplinas(disciplinas);
            GravarCursosDisciplinas(cursosDisciplinas);

            return true; 
        }

        private void LerExcel(string caminho, ref List<Curso> cursos, ref List<Disciplina> disciplinas, ref List<CursoDisciplina> cursosDisciplinas)
        {
            using (var stream = File.Open(caminho, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream);
                var dataSet = reader.AsDataSet();
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    if (row.ItemArray[0].ToString().ToLower() != "ano")
                    {
                        var curso = new Curso()
                        {
                            Id = row.ItemArray[6].ToString(),
                            Nome = row.ItemArray[7].ToString()
                        };

                        var disciplina = new Disciplina()
                        {
                            Id = row.ItemArray[2].ToString(),
                            Nome = row.ItemArray[3].ToString()
                        };

                        if (!cursos.Where(x => x.Id == curso.Id).Any())
                            cursos.Add(curso);

                        if (!disciplinas.Where(x => x.Id == disciplina.Id).Any())
                            disciplinas.Add(disciplina);

                        cursosDisciplinas.Add(new CursoDisciplina()
                        {               
                            Id = Guid.NewGuid(),
                            CodigoModelo = row.ItemArray[4].ToString(),
                            CursoId = row.ItemArray[6].ToString(),
                            DisciplinaId = row.ItemArray[2].ToString(),
                        });
                    }
                }
            }
        }

        private void GravarCursos(ICollection<Curso> cursos)
        {
            foreach (var item in cursos)
            {
                item.Ativo = true;
                _cursoRepository.Cadastrar(item);
            }
            _cursoRepository.Salvar();           
        }
        private void GravarDisciplinas(ICollection<Disciplina> disciplinas)
        {
            foreach (var item in disciplinas)
            {
                item.Ativo = true;
                _disciplinaRepository.Cadastrar(item);
            }
            _disciplinaRepository.Salvar();            
        }
        private void GravarCursosDisciplinas(ICollection<CursoDisciplina> cursosDiscplinas)
        {
            foreach (var item in cursosDiscplinas)
            {
                _cursoDisciplinaRepository.Cadastrar(item);
            }
            _cursoDisciplinaRepository.Salvar();            
        }
    }
}
