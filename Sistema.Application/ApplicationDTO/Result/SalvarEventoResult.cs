using Linx.Application.Results;
using Sistema.Application.ApplicationDTO.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Application.ApplicationDTO.Result
{
    public class SalvarEventoResult : ApiResult<EventoDto>
    {
        public SalvarEventoResult()
        {
        }

        public SalvarEventoResult(EventoDto result) : base(result)
        {
        }

        public SalvarEventoResult(IEnumerable<ApiError> errors) : base(errors)
        {
        }

        public SalvarEventoResult(params ApiError[] errors) : base(errors)
        {
        }

        public SalvarEventoResult(Exception ex) : base(ex)
        {
        }
    }
}
