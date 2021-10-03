using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WS_VentaReal_NetCore5.Models;
using WS_VentaReal_NetCore5.Models.Request;
using WS_VentaReal_NetCore5.Models.Response;
using WS_VentaReal_NetCore5.Services;

namespace WS_VentaReal_NetCore5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VentaController : ControllerBase
    {
        private IVentaService _venta;

        public VentaController(IVentaService venta)
        {
            this._venta = venta;
        }

        [HttpPost]
        public IActionResult Add(VentaRequest model)
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                //var venta = new VentaService();
                _venta.Add(model);
                respuesta.Exito = 1;

            }
            catch(Exception ex)
            {
                respuesta.Mensaje = ex.Message;

            }

            return Ok(respuesta);
        }
    }
}
