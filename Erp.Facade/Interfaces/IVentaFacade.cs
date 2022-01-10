using Erp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Facade.Interfaces
{
    public interface IVentaFacade
    {
        ResponseDto<int> Create(VentaRequestDto request);
        ResponseDto<VentaResponseDto> Get(int idVenta);
    }
}
