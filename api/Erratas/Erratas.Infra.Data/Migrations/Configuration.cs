namespace Erratas.Infra.Data.Migrations
{
    using Erratas.Domain.Entities;
    using Erratas.Infra.Data.Context;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EntityContext context)
        {
            //context.Item.Add(new Item() { Id = Guid.NewGuid(), Nome = "ATIVIDADE TELEAULA" });
            //context.Item.Add(new Item() { Id = Guid.NewGuid(), Nome = "AVALIAÇÃO" });
            //context.Item.Add(new Item() { Id = Guid.NewGuid(), Nome = "CARTA DE VISITA" });
            //context.Item.Add(new Item() { Id = Guid.NewGuid(), Nome = "CRONOGRAMA" });
            //context.Item.Add(new Item() { Id = Guid.NewGuid(), Nome = "EXAME" });
            //context.Item.Add(new Item() { Id = Guid.NewGuid(), Nome = "LIVRO-TEXTO" });
            //context.Item.Add(new Item() { Id = Guid.NewGuid(), Nome = "MANUAL" });
            //context.Item.Add(new Item() { Id = Guid.NewGuid(), Nome = "PERGUNTAS FREQUENTES" });
            //context.Item.Add(new Item() { Id = Guid.NewGuid(), Nome = "PLANO DE ENSINO" });
            //context.Item.Add(new Item() { Id = Guid.NewGuid(), Nome = "QUESTIONÁRIO" });
            //context.Item.Add(new Item() { Id = Guid.NewGuid(), Nome = "RESOLUÇÃO DO LIVRO-TEXTO" });
            //context.Item.Add(new Item() { Id = Guid.NewGuid(), Nome = "SLIDES DE AULA" });
            //context.Item.Add(new Item() { Id = Guid.NewGuid(), Nome = "TEXTO COMPLEMENTAR" });
            //context.Item.Add(new Item() { Id = Guid.NewGuid(), Nome = "VÍDEOAULA" });

            //context.Unidade.Add(new Unidade() { Id = Guid.NewGuid(), Nome = "Unidade I" });
            //context.Unidade.Add(new Unidade() { Id = Guid.NewGuid(), Nome = "Unidade II" });
            //context.Unidade.Add(new Unidade() { Id = Guid.NewGuid(), Nome = "Unidade III" });
            //context.Unidade.Add(new Unidade() { Id = Guid.NewGuid(), Nome = "Unidade IV" });
            //context.Unidade.Add(new Unidade() { Id = Guid.NewGuid(), Nome = "Unidade V" });
            //context.Unidade.Add(new Unidade() { Id = Guid.NewGuid(), Nome = "Unidade VI" });
            //context.Unidade.Add(new Unidade() { Id = Guid.NewGuid(), Nome = "Unidade VII" });
            //context.Unidade.Add(new Unidade() { Id = Guid.NewGuid(), Nome = "Unidade VIII" });

            //context.Instituto.Add(new Instituto() { Id = Guid.NewGuid(), Descricao = "Associadas" });
            //context.Instituto.Add(new Instituto() { Id = Guid.NewGuid(), Descricao = "EaD" });
            //context.Instituto.Add(new Instituto() { Id = Guid.NewGuid(), Descricao = "UNIP Presencial" });

            //context.MotivoErrata.Add(new MotivoErrata() { Id = Guid.NewGuid(), Descricao = "Planejamento" });
            //context.MotivoErrata.Add(new MotivoErrata() { Id = Guid.NewGuid(), Descricao = "Plataforma Acadêmica" });
            //context.MotivoErrata.Add(new MotivoErrata() { Id = Guid.NewGuid(), Descricao = "Professor" });

            //context.Modulo.Add(new Modulo() { Id = Guid.Parse("D738D0D1-C819-42F7-B4C1-2E3A7FF51511"), Nome = "Usuários" });
            //context.Modulo.Add(new Modulo() { Id = Guid.Parse("81C3FF27-3207-4536-8454-40B6D69F6C15"), Nome = "Cargos" });
            //context.Modulo.Add(new Modulo() { Id = Guid.Parse("168386D5-E2AA-46FE-8739-D5F82C979713"), Nome = "Logs" });
            //context.Modulo.Add(new Modulo() { Id = Guid.Parse("C77EF579-AB6A-4AF1-A310-C3FFDD367ADA"), Nome = "Permissões" });
            //context.Modulo.Add(new Modulo() { Id = Guid.Parse("63EC2957-A7C5-4B5D-96EA-D0465E6EB1C6"), Nome = "Erratas" });
            //context.Modulo.Add(new Modulo() { Id = Guid.Parse("EE70A96E-0BDC-46CA-A261-94DE0D53BDA8"), Nome = "Disciplinas" });
            //context.Modulo.Add(new Modulo() { Id = Guid.Parse("92233672-F418-4C0C-85A9-45A4E7041445"), Nome = "Cursos" });
            //context.Modulo.Add(new Modulo() { Id = Guid.Parse("d3ad2a38-50ce-4bcb-89ce-63231c0a88d2"), Nome = "Relatórios" });

            //context.Cargo.Add(new Cargo() { Id = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), Nome = "Admin", Ativo = true });
            //context.Cargo.Add(new Cargo() { Id = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), Nome = "Gestor", Ativo = true });
            //context.Cargo.Add(new Cargo() { Id = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), Nome = "Operador", Ativo = true });

            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("37CA7678-925B-4B40-846E-CEC5F5405908"), Abreviacao = "CU", Descricao = "Cadastrar Usuarios", ModuloId = Guid.Parse("D738D0D1-C819-42F7-B4C1-2E3A7FF51511") });
            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("DE6298DF-7E85-4E7D-BBA4-327EC7E45CE9"), Abreviacao = "AU", Descricao = "Atualizar Usuarios", ModuloId = Guid.Parse("D738D0D1-C819-42F7-B4C1-2E3A7FF51511") });
            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("A8DEA0C8-FCB6-44B0-9214-4BDECD8B9895"), Abreviacao = "RU", Descricao = "Remover Usuarios", ModuloId = Guid.Parse("D738D0D1-C819-42F7-B4C1-2E3A7FF51511") });
            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("B329EFBD-24A1-4B40-A626-48AC198A5397"), Abreviacao = "LU", Descricao = "Listar Usuarios", ModuloId = Guid.Parse("D738D0D1-C819-42F7-B4C1-2E3A7FF51511") });
            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("12634409-62A9-44C5-9E22-B67E105A1912"), Abreviacao = "OU", Descricao = "Obter Usuarios", ModuloId = Guid.Parse("D738D0D1-C819-42F7-B4C1-2E3A7FF51511") });
            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("445B0DFE-691A-4EDD-B656-C04AA0A24AB3"), Abreviacao = "ZS", Descricao = "Zerar Senha", ModuloId = Guid.Parse("D738D0D1-C819-42F7-B4C1-2E3A7FF51511") });


            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("32ce65e3-a105-4a67-bd30-2d431ab41580"), Abreviacao = "CC", Descricao = "Cadastrar Cargos", ModuloId = Guid.Parse("81C3FF27-3207-4536-8454-40B6D69F6C15") });
            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("1dd9b4dd-d4e7-4b42-810c-0ba00a55f620"), Abreviacao = "AC", Descricao = "Atualizar Cargos", ModuloId = Guid.Parse("81C3FF27-3207-4536-8454-40B6D69F6C15") });
            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("57e286df-aef8-4790-9c83-fc02fa46e711"), Abreviacao = "RC", Descricao = "Remover Cargos", ModuloId = Guid.Parse("81C3FF27-3207-4536-8454-40B6D69F6C15") });
            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("3676f05e-5856-4f09-bd6e-2d8a0c233f1b"), Abreviacao = "LC", Descricao = "Listar Cargos", ModuloId = Guid.Parse("81C3FF27-3207-4536-8454-40B6D69F6C15") });
            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("D0F68041-E1FD-4490-935D-048038DAF9DF"), Abreviacao = "OC", Descricao = "Obter Cargos", ModuloId = Guid.Parse("81C3FF27-3207-4536-8454-40B6D69F6C15") });

            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("711B351C-8726-4C15-8D84-787755C54AE5"), Abreviacao = "LP", Descricao = "Listar Permissoes", ModuloId = Guid.Parse("C77EF579-AB6A-4AF1-A310-C3FFDD367ADA") });
            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("E28854FB-DD66-4646-B4EE-EC8FE5E23D02"), Abreviacao = "AP", Descricao = "Atualizar Permissoes", ModuloId = Guid.Parse("C77EF579-AB6A-4AF1-A310-C3FFDD367ADA") });
            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("C12F6DDC-7E54-4348-B24C-C458F186F302"), Abreviacao = "APM", Descricao = "Autorizacao Por Modulo", ModuloId = Guid.Parse("C77EF579-AB6A-4AF1-A310-C3FFDD367ADA") });

            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("D50FA38A-8B38-4272-B3AB-706606A18C30"), Abreviacao = "LL", Descricao = "Listar Logs", ModuloId = Guid.Parse("168386D5-E2AA-46FE-8739-D5F82C979713") });
            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("99D8C227-276B-4BDE-898F-60832675361D"), Abreviacao = "OL", Descricao = "Obter Logs", ModuloId = Guid.Parse("168386D5-E2AA-46FE-8739-D5F82C979713") });

            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("D8C9A7BD-B6B9-4A03-87CD-18B59D80F3F9"), Abreviacao = "LE", Descricao = "Listar Erratas", ModuloId = Guid.Parse("63EC2957-A7C5-4B5D-96EA-D0465E6EB1C6") });
            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("B461B445-9F1E-45A5-9459-1D3936C41B93"), Abreviacao = "OE", Descricao = "Obter Erratas", ModuloId = Guid.Parse("63EC2957-A7C5-4B5D-96EA-D0465E6EB1C6") });
            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("D7A03BF0-EB81-4861-8758-AE4B535CEFE9"), Abreviacao = "CE", Descricao = "Cadastrar Erratas", ModuloId = Guid.Parse("63EC2957-A7C5-4B5D-96EA-D0465E6EB1C6") });
            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("0C373647-0338-4AFD-A520-0AB3DA85B3C0"), Abreviacao = "AE", Descricao = "Atualizar Erratas", ModuloId = Guid.Parse("63EC2957-A7C5-4B5D-96EA-D0465E6EB1C6") });

            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("FEAFB01E-FEAA-4F03-BEC7-3C631EA92D80"), Abreviacao = "LD", Descricao = "Listar Disciplinas", ModuloId = Guid.Parse("EE70A96E-0BDC-46CA-A261-94DE0D53BDA8") });
            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("DA9A75B1-8971-426A-A6F2-1833A8E18788"), Abreviacao = "OD", Descricao = "Obter Disciplinas", ModuloId = Guid.Parse("EE70A96E-0BDC-46CA-A261-94DE0D53BDA8") });
            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("4E20C14A-779D-4B46-9749-AF9702C564D6"), Abreviacao = "CD", Descricao = "Cadastrar Disciplinas", ModuloId = Guid.Parse("EE70A96E-0BDC-46CA-A261-94DE0D53BDA8") });
            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("9C0ADA92-1CB8-4B71-A9CA-DD70E0017B29"), Abreviacao = "AD", Descricao = "Atualizar Disciplinas", ModuloId = Guid.Parse("EE70A96E-0BDC-46CA-A261-94DE0D53BDA8") });
            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("F5FE02CD-5F3E-4EC1-9F95-6504C6BEF7E9"), Abreviacao = "RD", Descricao = "Remover Disciplinas", ModuloId = Guid.Parse("EE70A96E-0BDC-46CA-A261-94DE0D53BDA8") });

            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("A0FED272-295F-4612-BFE7-09740D841D43"), Abreviacao = "LCU", Descricao = "Listar Cursos", ModuloId = Guid.Parse("92233672-F418-4C0C-85A9-45A4E7041445") });
            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("84EC42AB-5FC1-4DB5-96D6-1E84EFEC32EE"), Abreviacao = "OCU", Descricao = "Obter Cursos", ModuloId = Guid.Parse("92233672-F418-4C0C-85A9-45A4E7041445") });
            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("1A687FDF-FA60-49D3-8182-8923FF0DB6B2"), Abreviacao = "CCU", Descricao = "Cadastrar Cursos", ModuloId = Guid.Parse("92233672-F418-4C0C-85A9-45A4E7041445") });
            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("CA30657B-12C7-494C-89BC-06659EF83257"), Abreviacao = "ACU", Descricao = "Atualizar Cursos", ModuloId = Guid.Parse("92233672-F418-4C0C-85A9-45A4E7041445") });
            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("2AD4F870-3940-4FFD-8953-DE3839C97D17"), Abreviacao = "RCU", Descricao = "Remover Cursos", ModuloId = Guid.Parse("92233672-F418-4C0C-85A9-45A4E7041445") });

            //context.Permissoes.Add(new Permissao() { Id = Guid.Parse("97859348-7c61-4ae6-a59f-d75280fc361e"), Abreviacao = "VR", Descricao = "Visualizar Relatorios", ModuloId = Guid.Parse("d3ad2a38-50ce-4bcb-89ce-63231c0a88d2") });

            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("DE6298DF-7E85-4E7D-BBA4-327EC7E45CE9"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("B329EFBD-24A1-4B40-A626-48AC198A5397"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("A8DEA0C8-FCB6-44B0-9214-4BDECD8B9895"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("37CA7678-925B-4B40-846E-CEC5F5405908"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("445B0DFE-691A-4EDD-B656-C04AA0A24AB3"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("12634409-62A9-44C5-9E22-B67E105A1912"), Autorizado = false });


            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("32ce65e3-a105-4a67-bd30-2d431ab41580"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("1dd9b4dd-d4e7-4b42-810c-0ba00a55f620"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("57e286df-aef8-4790-9c83-fc02fa46e711"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("3676f05e-5856-4f09-bd6e-2d8a0c233f1b"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("D0F68041-E1FD-4490-935D-048038DAF9DF"), Autorizado = false });

            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("711B351C-8726-4C15-8D84-787755C54AE5"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("E28854FB-DD66-4646-B4EE-EC8FE5E23D02"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("C12F6DDC-7E54-4348-B24C-C458F186F302"), Autorizado = false });

            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("D50FA38A-8B38-4272-B3AB-706606A18C30"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("99D8C227-276B-4BDE-898F-60832675361D"), Autorizado = false });

            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("D8C9A7BD-B6B9-4A03-87CD-18B59D80F3F9"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("B461B445-9F1E-45A5-9459-1D3936C41B93"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("D7A03BF0-EB81-4861-8758-AE4B535CEFE9"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("0C373647-0338-4AFD-A520-0AB3DA85B3C0"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("FEAFB01E-FEAA-4F03-BEC7-3C631EA92D80"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("DA9A75B1-8971-426A-A6F2-1833A8E18788"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("4E20C14A-779D-4B46-9749-AF9702C564D6"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("9C0ADA92-1CB8-4B71-A9CA-DD70E0017B29"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("F5FE02CD-5F3E-4EC1-9F95-6504C6BEF7E9"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("A0FED272-295F-4612-BFE7-09740D841D43"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("84EC42AB-5FC1-4DB5-96D6-1E84EFEC32EE"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("1A687FDF-FA60-49D3-8182-8923FF0DB6B2"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("CA30657B-12C7-494C-89BC-06659EF83257"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("2AD4F870-3940-4FFD-8953-DE3839C97D17"), Autorizado = false });

            // context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4EE331A7-D872-46D1-83F0-A1E69F9ECCAA"), PermissaoId = Guid.Parse("97859348-7c61-4ae6-a59f-d75280fc361e"), Autorizado = false });


            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("DE6298DF-7E85-4E7D-BBA4-327EC7E45CE9"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("B329EFBD-24A1-4B40-A626-48AC198A5397"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("A8DEA0C8-FCB6-44B0-9214-4BDECD8B9895"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("37CA7678-925B-4B40-846E-CEC5F5405908"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("445B0DFE-691A-4EDD-B656-C04AA0A24AB3"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("12634409-62A9-44C5-9E22-B67E105A1912"), Autorizado = false });


            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("32ce65e3-a105-4a67-bd30-2d431ab41580"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("1dd9b4dd-d4e7-4b42-810c-0ba00a55f620"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("57e286df-aef8-4790-9c83-fc02fa46e711"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("3676f05e-5856-4f09-bd6e-2d8a0c233f1b"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("D0F68041-E1FD-4490-935D-048038DAF9DF"), Autorizado = false });

            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("711B351C-8726-4C15-8D84-787755C54AE5"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("E28854FB-DD66-4646-B4EE-EC8FE5E23D02"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("C12F6DDC-7E54-4348-B24C-C458F186F302"), Autorizado = false });

            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("D50FA38A-8B38-4272-B3AB-706606A18C30"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("99D8C227-276B-4BDE-898F-60832675361D"), Autorizado = false });

            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("D8C9A7BD-B6B9-4A03-87CD-18B59D80F3F9"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("B461B445-9F1E-45A5-9459-1D3936C41B93"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("D7A03BF0-EB81-4861-8758-AE4B535CEFE9"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("0C373647-0338-4AFD-A520-0AB3DA85B3C0"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("FEAFB01E-FEAA-4F03-BEC7-3C631EA92D80"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("DA9A75B1-8971-426A-A6F2-1833A8E18788"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("4E20C14A-779D-4B46-9749-AF9702C564D6"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("9C0ADA92-1CB8-4B71-A9CA-DD70E0017B29"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("F5FE02CD-5F3E-4EC1-9F95-6504C6BEF7E9"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("A0FED272-295F-4612-BFE7-09740D841D43"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("84EC42AB-5FC1-4DB5-96D6-1E84EFEC32EE"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("1A687FDF-FA60-49D3-8182-8923FF0DB6B2"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("CA30657B-12C7-494C-89BC-06659EF83257"), Autorizado = false });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("2AD4F870-3940-4FFD-8953-DE3839C97D17"), Autorizado = false });

            // context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), PermissaoId = Guid.Parse("97859348-7c61-4ae6-a59f-d75280fc361e"), Autorizado = false });


            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("DE6298DF-7E85-4E7D-BBA4-327EC7E45CE9"), Autorizado = true });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("B329EFBD-24A1-4B40-A626-48AC198A5397"), Autorizado = true });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("A8DEA0C8-FCB6-44B0-9214-4BDECD8B9895"), Autorizado = true });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("37CA7678-925B-4B40-846E-CEC5F5405908"), Autorizado = true });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("445B0DFE-691A-4EDD-B656-C04AA0A24AB3"), Autorizado = true });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("12634409-62A9-44C5-9E22-B67E105A1912"), Autorizado = true });


            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("32ce65e3-a105-4a67-bd30-2d431ab41580"), Autorizado = true });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("1dd9b4dd-d4e7-4b42-810c-0ba00a55f620"), Autorizado = true });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("57e286df-aef8-4790-9c83-fc02fa46e711"), Autorizado = true });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("3676f05e-5856-4f09-bd6e-2d8a0c233f1b"), Autorizado = true });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("D0F68041-E1FD-4490-935D-048038DAF9DF"), Autorizado = true });

            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("711B351C-8726-4C15-8D84-787755C54AE5"), Autorizado = true });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("E28854FB-DD66-4646-B4EE-EC8FE5E23D02"), Autorizado = true });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("C12F6DDC-7E54-4348-B24C-C458F186F302"), Autorizado = true });

            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("D50FA38A-8B38-4272-B3AB-706606A18C30"), Autorizado = true });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("99D8C227-276B-4BDE-898F-60832675361D"), Autorizado = true });

            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("D8C9A7BD-B6B9-4A03-87CD-18B59D80F3F9"), Autorizado = true });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("B461B445-9F1E-45A5-9459-1D3936C41B93"), Autorizado = true });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("D7A03BF0-EB81-4861-8758-AE4B535CEFE9"), Autorizado = true });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("0C373647-0338-4AFD-A520-0AB3DA85B3C0"), Autorizado = true });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("FEAFB01E-FEAA-4F03-BEC7-3C631EA92D80"), Autorizado = true });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("DA9A75B1-8971-426A-A6F2-1833A8E18788"), Autorizado = true });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("4E20C14A-779D-4B46-9749-AF9702C564D6"), Autorizado = true });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("9C0ADA92-1CB8-4B71-A9CA-DD70E0017B29"), Autorizado = true });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("F5FE02CD-5F3E-4EC1-9F95-6504C6BEF7E9"), Autorizado = true });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("A0FED272-295F-4612-BFE7-09740D841D43"), Autorizado = true });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("84EC42AB-5FC1-4DB5-96D6-1E84EFEC32EE"), Autorizado = true });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("1A687FDF-FA60-49D3-8182-8923FF0DB6B2"), Autorizado = true });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("CA30657B-12C7-494C-89BC-06659EF83257"), Autorizado = true });
            //context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("2AD4F870-3940-4FFD-8953-DE3839C97D17"), Autorizado = true });

            // context.CargoPermissoes.Add(new CargoPermissao() { Id = Guid.NewGuid(), CargoId = Guid.Parse("4AB8B22A-1A6B-45D7-A684-6CD348C84279"), PermissaoId = Guid.Parse("97859348-7c61-4ae6-a59f-d75280fc361e"), Autorizado = true });
			

	
            // context.Departamento.Add(new Departamento() { Id = Guid.Parse("0810fca2-536f-4a44-9287-700ca8a58673"), Nome = "Planejamento" });
            // context.Departamento.Add(new Departamento() { Id = Guid.Parse("983e7424-4008-400f-b062-24fba0053312"), Nome = "Plataforma Acadêmica" });

            //context.Usuario.Add(new Usuario() { Id = Guid.NewGuid(), DepartamentoId = Guid.Parse("983e7424-4008-400f-b062-24fba0053312"), Nome = "Anderson", SobreNome = "Souza", Email = "anderson.souza@unip.br", Senha = "95f695e444ec73f6aeefb6af0aa6d130", CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), Ativo = true });
            //context.Usuario.Add(new Usuario() { Id = Guid.NewGuid(), DepartamentoId = Guid.Parse("983e7424-4008-400f-b062-24fba0053312"), Nome = "Educação", SobreNome = "Digital", Email = "edd.dev@unip.br", Senha = "95f695e444ec73f6aeefb6af0aa6d130", CargoId = Guid.Parse("BD3C8CDC-844E-401D-A593-5E4AD033B2C5"), Ativo = true });

        }
    }
}
