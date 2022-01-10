using Erp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Facade.Interfaces
{
    public interface IClienteFacade
    {
        ResponseDto<bool> Create(ClienteDto request);
        ResponseDto<bool> Delete(int idCliente);
        ResponseDto<IList<ClienteDto>> GetAll();
        ResponseDto<bool> Update(ClienteDto request);
    }
}
