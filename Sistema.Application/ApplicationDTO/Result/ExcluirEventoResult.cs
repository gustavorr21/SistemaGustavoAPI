using Linx.Application.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Application.ApplicationDTO.Result
{
    public class ExcluirEventoResult : ApiResult
    {
        public ExcluirEventoResult()
        {
        }

        public ExcluirEventoResult(IEnumerable<ApiError> errors) : base(errors)
        {
        }

        public ExcluirEventoResult(params ApiError[] errors) : base(errors)
        {
        }

        public ExcluirEventoResult(Exception ex) : base(ex)
        {
        }
    }
}
