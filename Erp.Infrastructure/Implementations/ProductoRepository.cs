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
    public class ProductoRepository : IProductoRepository
    {
        private readonly DbContextApi context;

        public ProductoRepository(DbContextApi _context)
        {
            this.context = _context;
        }

        public ResponseDto<bool> Create(ProductoDto request)
        {
            var response = new ResponseDto<bool>();

            try
            {
                Producto entity = new Producto
                {
                    IdProducto = 0,
                    Nombre = request.Nombre,
                    ValorUnitario = request.ValorUnitario
                };

                context.Productos.Add(entity);
                context.SaveChanges();

                response.Result = true;
            }
            catch (Exception ex)
            {
                response.SetData(HttpStatusCode.InternalServerError, ex.Message, false);
            }

            return response;
        }

        public ResponseDto<bool> Delete(int idProducto)
        {
            var response = new ResponseDto<bool>();

            try
            {
                Producto entity = context.Productos.Find(idProducto);

                context.Productos.Remove(entity);
                context.SaveChanges();

                response.Result = true;
            }
            catch (Exception ex)
            {
                response.SetData(HttpStatusCode.InternalServerError, ex.Message, false);
            }

            return response;
        }

        public ResponseDto<IList<ProductoDto>> GetAll()
        {
            var response = new ResponseDto<IList<ProductoDto>>();

            try
            {
                response.Result =
                    context.Productos
                    .Select(x => new ProductoDto
                    {
                        IdProducto = x.IdProducto,
                        Nombre = x.Nombre,
                        ValorUnitario = x.ValorUnitario
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                response.SetData(HttpStatusCode.InternalServerError, ex.Message, null);
            }

            return response;
        }

        public ResponseDto<bool> Update(ProductoDto request)
        {
            var response = new ResponseDto<bool>();

            try
            {
                Producto entity = context.Productos.Find(request.IdProducto);
                entity.Nombre = request.Nombre;
                entity.ValorUnitario = request.ValorUnitario;

                context.SaveChanges();

                response.Result = true;
            }
            catch (Exception ex)
            {
                response.SetData(HttpStatusCode.InternalServerError, ex.Message, false);
            }

            return response;
        }
    }
}
