using Erp.Dto;
using Erp.Facade.Interfaces;
using Erp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Facade.Implementations
{
    public class ClienteFacade : IClienteFacade
    {
        private readonly IClienteRepository repository;

        public ClienteFacade(IClienteRepository _repository)
        {
            this.repository = _repository;
        }

        public ResponseDto<bool> Create(ClienteDto request)
        {
            return repository.Create(request);
        }

        public ResponseDto<bool> Delete(int idCliente)
        {
            return repository.Delete(idCliente);
        }

        public ResponseDto<IList<ClienteDto>> GetAll()
        {
            return repository.GetAll();
        }

        public ResponseDto<bool> Update(ClienteDto request)
        {
            return repository.Update(request);
        }
    }
}
