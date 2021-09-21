using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WS_VentaReal_NetCore5.Models;
using WS_VentaReal_NetCore5.Models.Request;
using WS_VentaReal_NetCore5.Models.Response;

namespace WS_VentaReal_NetCore5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            //oRespuesta.Exito = 0;
            try
            {

                using (VentaRealContext db = new VentaRealContext())
                {
                    var list = db.Clientes.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = list;
                    
                }
            }
            catch (Exception ex) {
                oRespuesta.Mensaje = ex.Message;
            }
             
            return Ok(oRespuesta);


        }

        [HttpPost]
        public IActionResult Add(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            
            try
            {

                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente ocliente = new Cliente();
                    ocliente.Nombre = oModel.Nombre;
                    db.Clientes.Add(ocliente);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;

                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Edit(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente ocliente = db.Clientes.Find(oModel.Id);
                    ocliente.Nombre = oModel.Nombre;
                    db.Entry(ocliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;

                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente ocliente = db.Clientes.Find(Id);
                    db.Remove(ocliente);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;

                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
    }
}
