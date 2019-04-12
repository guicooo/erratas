using Erratas.Application.Models;
using Erratas.Application.Models.Cursos;
using Erratas.Application.Models.Disciplinas;
using Erratas.Application.Models.Erratas;
using Erratas.Application.Models.Usuarios;
using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;


namespace Erratas.Application.Adapters
{
    public class ErrataAdapter
    {
        public Errata FormDataParaErrata(Guid ErrataId)
        {
            var errata = new Errata();
            errata.Id = ErrataId;

            foreach (var item in typeof(Errata).GetProperties())
            {
                if (!string.IsNullOrEmpty(HttpContext.Current.Request.Form[item.Name]))
                {
                    if (item.Name == "ErrataCursos")
                    {
                        if (!string.IsNullOrEmpty(HttpContext.Current.Request.Form[item.Name]))
                        {
                            var valores = HttpContext.Current.Request.Form[item.Name].Split(',');

                            foreach (var valor in valores)
                            {
                                errata.ErrataCursos.Add(new ErrataCurso() { Id = Guid.NewGuid(), ErrataId = errata.Id, CursoId = valor.ToString() });
                            }
                        }                       
                    }
                    else if (item.Name == "ImagensErrata")
                    {
                        if (!string.IsNullOrEmpty(HttpContext.Current.Request.Form[item.Name]))
                        {
                            var valores = HttpContext.Current.Request.Form[item.Name].Split(',');

                            foreach (var valor in valores)
                            {
                                var nome = Guid.NewGuid();
                                var caminho = "/Arquivos/Imagens/" + nome + ".jpg";
                                errata.ImagensErrata.Add(new ImagemErrata() { Id = Guid.NewGuid(), ErratasId = errata.Id, CaminhoImagem = caminho });
                                byte[] bytes = Convert.FromBase64String(valor);
                                Image image;
                                using (MemoryStream ms = new MemoryStream(bytes))
                                {
                                    image = Image.FromStream(ms);                                   
                                    image.Save(HttpContext.Current.Server.MapPath("~/") + "\\" + caminho, ImageFormat.Jpeg);
                                }
                            }
                        }
                    }
                    else
                    {
                        var valor = new Object();
                        if (item.PropertyType.FullName == "System.DateTime" && HttpContext.Current.Request.Form[item.Name].Contains("T"))
                            valor = DateTime.ParseExact(HttpContext.Current.Request.Form[item.Name], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                        else if (item.PropertyType.FullName == "System.DateTime")
                            valor = DateTime.ParseExact(HttpContext.Current.Request.Form[item.Name], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        else
                            valor = TypeDescriptor.GetConverter(item.PropertyType).ConvertFromInvariantString(HttpContext.Current.Request.Form[item.Name]);

                        item.SetValue(errata, valor, null);
                    }
                    
                }                  
            }                    

            return errata;
        }

        public ObterErrataModel ErrataParaObterErrataModel(Errata errata)
        {
            var obterErrataModel = new ObterErrataModel();
            obterErrataModel.Unidade = errata.Unidade;
            obterErrataModel.Instituto = errata.Instituto;
            obterErrataModel.Id = errata.Id;
            obterErrataModel.Professor = errata.Professor;           
            obterErrataModel.MotivoErrata = errata.MotivoErrata;
            obterErrataModel.AvisoPostado = errata.AvisoPostado;
            obterErrataModel.CodigoModelo = errata.CodigoModelo;
            obterErrataModel.CodigoOferta = errata.CodigoOferta;
            obterErrataModel.DataDeSolicitacao = errata.DataDeSolicitacao;
            obterErrataModel.Descricao = errata.Descricao;

            obterErrataModel.Item = new Item()
            {
                Id = errata.Item.Id,
                Nome = errata.Item.Nome
            };

            obterErrataModel.Disciplina = new Disciplina()
            {
                Id = errata.Disciplina.Id,
                Nome = errata.Disciplina.Nome
            };

            obterErrataModel.MotivoErrata = new MotivoErrata()
            {
                Id = errata.MotivoErrata.Id,
                Descricao = errata.MotivoErrata.Descricao
            };

            obterErrataModel.ResponsavelInsercao = new ObterUsuarioModel()
            {
                Id =  errata.ResponsavelInsercao.Id,
                Cargo = new CargoModel()
                {
                    Id = errata.ResponsavelInsercao.Cargo.Id,
                    Nome = errata.ResponsavelInsercao.Cargo.Nome
                },
                Email = errata.ResponsavelInsercao.Email,
                Nome = errata.ResponsavelInsercao.Nome,
                SobreNome = errata.ResponsavelInsercao.SobreNome
            };

            obterErrataModel.ResponsavelRevisao = new ObterUsuarioModel()
            {
                Id = errata.ResponsavelRevisao.Id,
                Cargo = new CargoModel()
                {
                    Id = errata.ResponsavelRevisao.Cargo.Id,
                    Nome = errata.ResponsavelRevisao.Cargo.Nome
                },
                Email = errata.ResponsavelRevisao.Email,
                Nome = errata.ResponsavelRevisao.Nome,
                SobreNome = errata.ResponsavelRevisao.SobreNome
            };

            foreach(var item in errata.ImagensErrata)
            {
                obterErrataModel.ImagensErrata.Add(new ImagemErrataModel()
                {
                    Id = item.Id,
                    Caminho = item.CaminhoImagem
                });
            }

            foreach (var item in errata.ErrataCursos)
            {
                obterErrataModel.ErrataCursos.Add(new CursoModel() 
                {
                    Id = item.Curso.Id,
                    Nome =  item.Curso.Nome
                });
            }
           
            return obterErrataModel;
        }

        public IEnumerable<ObterErrataModel> ErrataParaListaErrataModel(IEnumerable<Errata> errata)
        {
            var erratas = new List<ObterErrataModel>();

            foreach(var item in errata)
            {
                var obterErrataModel = new ObterErrataModel();
                obterErrataModel.Unidade = item.Unidade;
                obterErrataModel.Instituto = item.Instituto;
                obterErrataModel.Id = item.Id;
                obterErrataModel.Professor = item.Professor;
                obterErrataModel.MotivoErrata = item.MotivoErrata;
                obterErrataModel.AvisoPostado = item.AvisoPostado;
                obterErrataModel.CodigoModelo = item.CodigoModelo;
                obterErrataModel.CodigoOferta = item.CodigoOferta;
                obterErrataModel.DataDeSolicitacao = item.DataDeSolicitacao;
                obterErrataModel.Descricao = item.Descricao;

                obterErrataModel.Item = new Item()
                {
                    Id = item.Item.Id,
                    Nome = item.Item.Nome
                };

                obterErrataModel.Disciplina = new Disciplina()
                {
                    Id = item.Disciplina.Id,
                    Nome = item.Disciplina.Nome
                };

                obterErrataModel.MotivoErrata = new MotivoErrata()
                {
                    Id = item.MotivoErrata.Id,
                    Descricao = item.MotivoErrata.Descricao
                };
                
                obterErrataModel.ResponsavelInsercao = new ObterUsuarioModel()
                {
                    Cargo = new CargoModel()
                    {
                        Id = item.ResponsavelInsercao.Cargo.Id,
                        Nome = item.ResponsavelInsercao.Cargo.Nome
                    },
                    Email = item.ResponsavelInsercao.Email,
                    Nome = item.ResponsavelInsercao.Nome,
                    SobreNome = item.ResponsavelInsercao.SobreNome
                };

                obterErrataModel.ResponsavelRevisao = new ObterUsuarioModel()
                {
                    Cargo = new CargoModel()
                    {
                        Id = item.ResponsavelRevisao.Cargo.Id,
                        Nome = item.ResponsavelRevisao.Cargo.Nome
                    },
                    Email = item.ResponsavelRevisao.Email,
                    Nome = item.ResponsavelRevisao.Nome,
                    SobreNome = item.ResponsavelRevisao.SobreNome
                };

                foreach (var itemI in item.ImagensErrata)
                {
                    obterErrataModel.ImagensErrata.Add(new ImagemErrataModel()
                    {
                        Id = itemI.Id,
                        Caminho = itemI.CaminhoImagem
                    });
                }

                foreach (var itemC in item.ErrataCursos)
                {
                    obterErrataModel.ErrataCursos.Add(new CursoModel()
                    {
                        Id = itemC.Curso.Id,
                        Nome = itemC.Curso.Nome
                    });
                }

                erratas.Add(obterErrataModel);
            }

            return erratas;
        }
    }
}
