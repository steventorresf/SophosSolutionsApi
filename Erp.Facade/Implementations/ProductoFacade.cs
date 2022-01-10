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
    public class ProductoFacade : IProductoFacade
    {
        private readonly IProductoRepository repository;

        public ProductoFacade(IProductoRepository _repository)
        {
            this.repository = _repository;
        }

        public ResponseDto<bool> Create(ProductoDto request)
        {
            return repository.Create(request);
        }

        public ResponseDto<bool> Delete(int idProducto)
        {
            return repository.Delete(idProducto);
        }

        public ResponseDto<IList<ProductoDto>> GetAll()
        {
            return repository.GetAll();
        }

        public ResponseDto<bool> Update(ProductoDto request)
        {
            return repository.Update(request);
        }
    }
}
