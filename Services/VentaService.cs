using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WS_VentaReal_NetCore5.Models;
using WS_VentaReal_NetCore5.Models.Request;

namespace WS_VentaReal_NetCore5.Services
{
    public class VentaService : IVentaService
    {
        public void Add(VentaRequest model)
        {
            using (VentaRealContext db = new VentaRealContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var venta = new Venta();
                        venta.Total = model.Conceptos.Sum(d => d.Cantidad * d.PrecioUnitario); // model.Total;
                        venta.Fecha = DateTime.Now;
                        venta.IdCliente = model.IdCliente;
                        db.Ventas.Add(venta);
                        db.SaveChangesAsync();

                        foreach (var modelconcepto in model.Conceptos)
                        {
                            var concepto = new Models.Concepto();
                            concepto.Cantidad = modelconcepto.Cantidad;
                            concepto.IdProducto = modelconcepto.IdProducto;
                            concepto.PrecioUnitario = modelconcepto.PrecioUnitario;
                            concepto.Importe = modelconcepto.Importe;
                            concepto.IdVenta = venta.Id;
                            db.Conceptos.Add(concepto);
                            db.SaveChanges();
                        }

                        transaction.Commit();
                        //respuesta.Exito = 1;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw new Exception("Ocurrio un error en la insercion");
                    }
                }

            }
        }
    }
}
