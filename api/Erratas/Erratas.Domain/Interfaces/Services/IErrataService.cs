﻿using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Interfaces.Services
{
    public interface IErrataService
    {
        Errata Cadastrar(Errata errata);
        Errata Atualizar(Errata errata);
    }
}
