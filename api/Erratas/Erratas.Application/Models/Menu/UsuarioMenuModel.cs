﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Models.Menu
{
    public class UsuarioMenuModel
    {
        public bool Obter { get; set; }
        public bool Cadastrar { get; set; }
        public bool Atualizar { get; set; }
        public bool Listar { get; set; }
        public bool Remover { get; set; }
        public bool ZerarSenha { get; set; }

    }
}
