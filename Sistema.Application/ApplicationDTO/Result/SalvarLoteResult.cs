using Linx.Application.Results;
using Sistema.Application.ApplicationDTO.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Application.ApplicationDTO.Result
{
    public class SalvarLoteResult : ApiResult<LotesDto>
    {
        public SalvarLoteResult()
        {
        }

        public SalvarLoteResult(LotesDto result) : base(result)
        {
        }

        public SalvarLoteResult(IEnumerable<ApiError> errors) : base(errors)
        {
        }

        public SalvarLoteResult(params ApiError[] errors) : base(errors)
        {
        }

        public SalvarLoteResult(Exception ex) : base(ex)
        {
        }
    }
}
