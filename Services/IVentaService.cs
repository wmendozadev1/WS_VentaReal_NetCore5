﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WS_VentaReal_NetCore5.Models.Request;

namespace WS_VentaReal_NetCore5.Services
{
    public interface IVentaService
    {
        public void Add(VentaRequest model);
    }
}
