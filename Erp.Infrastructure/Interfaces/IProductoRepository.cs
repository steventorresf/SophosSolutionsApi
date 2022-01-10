using Erp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Infrastructure.Interfaces
{
    public interface IProductoRepository
    {
        ResponseDto<bool> Create(ProductoDto request);
        ResponseDto<bool> Delete(int idProducto);
        ResponseDto<IList<ProductoDto>> GetAll();
        ResponseDto<bool> Update(ProductoDto request);
    }
}
