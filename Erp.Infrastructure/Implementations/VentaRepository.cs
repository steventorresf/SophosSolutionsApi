using Erp.Dto;
using Erp.Entities;
using Erp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Infrastructure.Implementations
{
    public class VentaRepository : IVentaRepository
    {
        private readonly DbContextApi context;

        public VentaRepository(DbContextApi _context)
        {
            this.context = _context;
        }

        public ResponseDto<int> Create(VentaRequestDto request)
        {
            var response = new ResponseDto<int>();

            try
            {
                using(var tran = context.Database.BeginTransaction())
                {
                    Venta entity = new Venta
                    {
                        IdVenta = 0,
                        IdCliente = request.IdCliente,
                        FechaVenta = request.FechaVenta
                    };

                    context.Ventas.Add(entity);
                    context.SaveChanges();

                    int idVenta = context.Ventas.Max(x => x.IdVenta);

                    IList<VentaDetalle> entityDetalle = new List<VentaDetalle>();
                    foreach(var det in request.VentaDetalleList)
                    {
                        entityDetalle.Add(new VentaDetalle
                        {
                            IdVentaDetalle = 0,
                            IdVenta = idVenta,
                            IdProducto = det.IdProducto,
                            Cantidad = det.Cantidad,
                            ValorUnitario = det.ValorUnitario
                        });
                    }

                    context.VentasDetalle.AddRange(entityDetalle);
                    context.SaveChanges();

                    response.Result = idVenta;
                    
                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                response.SetData(HttpStatusCode.InternalServerError, ex.Message, -1);
            }

            return response;
        }

        public ResponseDto<VentaResponseDto> Get(int idVenta)
        {
            var response = new ResponseDto<VentaResponseDto>();

            try
            {
                response.Result = (from ve in context.Ventas.Where(x => x.IdVenta == idVenta)
                                   join cl in context.Clientes on ve.IdCliente equals cl.IdCliente
                                   select new VentaResponseDto
                                   {
                                       NoVenta = ve.IdVenta,
                                       NombreCliente = cl.Nombre + " "  + cl.Apellido,
                                       FechaVenta = ve.FechaVenta.ToString("dd/MM/yyyy"),
                                       VentaDetalleList = new List<VentaDetalleResponseDto>(),
                                   }).FirstOrDefault();

                response.Result.VentaDetalleList = (from vd in context.VentasDetalle.Where(x => x.IdVenta == idVenta)
                                                    join pr in context.Productos on vd.IdProducto equals pr.IdProducto
                                                    select new VentaDetalleResponseDto
                                                    {
                                                        NombreProducto = pr.Nombre,
                                                        Cantidad = vd.Cantidad,
                                                        ValorUnitario = vd.ValorUnitario,
                                                        ValorTotal = vd.Cantidad * vd.ValorUnitario
                                                    }).ToList();
            }
            catch (Exception ex)
            {
                response.SetData(HttpStatusCode.InternalServerError, ex.Message, null);
            }

            return response;
        }
    }
}
