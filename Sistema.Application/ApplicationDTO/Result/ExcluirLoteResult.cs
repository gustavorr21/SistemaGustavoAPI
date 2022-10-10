using Linx.Application.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Application.ApplicationDTO.Result
{
    public class ExcluirLoteResult : ApiResult
    {
        public ExcluirLoteResult()
        {
        }

        public ExcluirLoteResult(IEnumerable<ApiError> errors) : base(errors)
        {
        }

        public ExcluirLoteResult(params ApiError[] errors) : base(errors)
        {
        }

        public ExcluirLoteResult(Exception ex) : base(ex)
        {
        }
    }
}
