using Linx.Application.Results;
using Sistema.Application.ApplicationDTO.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Application.ApplicationDTO.Result
{
    public class SalvarUsuarioResult : ApiResult<UserDto>
    {
        public SalvarUsuarioResult()
        {
        }

        public SalvarUsuarioResult(UserDto result) : base(result)
        {
        }

        public SalvarUsuarioResult(IEnumerable<ApiError> errors) : base(errors)
        {
        }

        public SalvarUsuarioResult(params ApiError[] errors) : base(errors)
        {
        }

        public SalvarUsuarioResult(Exception ex) : base(ex)
        {
        }
    }
}
