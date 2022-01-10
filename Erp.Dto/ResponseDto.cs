using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Dto
{
    public class ResponseDto<T>
    {
        public bool Success { get; set; }
        public HttpStatusCode Status { get; set; }
        public T Result { get; set; }
        public string Message { get; set; }

        public ResponseDto()
        {
            this.Success = true;
            this.Status = HttpStatusCode.OK;
        }

        public void SetData(HttpStatusCode _status, string _message, T _result)
        {
            this.Success = false;
            this.Status = _status;
            this.Message = _message;
            this.Result = _result;
        }
    }
}
