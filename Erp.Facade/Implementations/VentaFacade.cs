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
    public class VentaFacade : IVentaFacade
    {
        private readonly IVentaRepository repository;

        public VentaFacade(IVentaRepository _repository)
        {
            this.repository = _repository;
        }

        public ResponseDto<int> Create(VentaRequestDto request)
        {
            return repository.Create(request);
        }

        public ResponseDto<VentaResponseDto> Get(int idVenta)
        {
            return repository.Get(idVenta);
        }
    }
}
