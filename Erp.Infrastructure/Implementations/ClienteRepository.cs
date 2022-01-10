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
    public class ClienteRepository : IClienteRepository
    {
        private readonly DbContextApi context;

        public ClienteRepository(DbContextApi _context)
        {
            this.context = _context;
        }

        public ResponseDto<bool> Create(ClienteDto request)
        {
            var response = new ResponseDto<bool>();

            try
            {
                Cliente entity = new Cliente
                {
                    IdCliente = 0,
                    Identificacion = request.Identificacion,
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    Telefono = request.Telefono
                };

                context.Clientes.Add(entity);
                context.SaveChanges();

                response.Result = true;
            }
            catch (Exception ex)
            {
                response.SetData(HttpStatusCode.InternalServerError, ex.Message, false);
            }

            return response;
        }

        public ResponseDto<bool> Delete(int idCliente)
        {
            var response = new ResponseDto<bool>();

            try
            {
                Cliente entity = context.Clientes.Find(idCliente);

                context.Clientes.Remove(entity);
                context.SaveChanges();

                response.Result = true;
            }
            catch (Exception ex)
            {
                response.SetData(HttpStatusCode.InternalServerError, ex.Message, false);
            }

            return response;
        }

        public ResponseDto<IList<ClienteDto>> GetAll()
        {
            var response = new ResponseDto<IList<ClienteDto>>();

            try
            {
                response.Result =
                    context.Clientes
                    .Select(x => new ClienteDto
                    {
                        IdCliente = x.IdCliente,
                        Identificacion = x.Identificacion,
                        Nombre = x.Nombre,
                        Apellido = x.Apellido,
                        Telefono = x.Telefono,
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                response.SetData(HttpStatusCode.InternalServerError, ex.Message, null);
            }

            return response;
        }

        public ResponseDto<bool> Update(ClienteDto request)
        {
            var response = new ResponseDto<bool>();

            try
            {
                Cliente entity = context.Clientes.Find(request.IdCliente);
                entity.Identificacion = request.Identificacion;
                entity.Nombre = request.Nombre;
                entity.Apellido = request.Apellido;
                entity.Telefono = request.Telefono;

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
