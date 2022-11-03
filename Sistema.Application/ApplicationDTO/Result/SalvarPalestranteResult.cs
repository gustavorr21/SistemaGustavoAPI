using Linx.Application.Results;
using Sistema.Application.ApplicationDTO.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Application.ApplicationDTO.Result
{
    public class SalvarPalestranteResult : ApiResult<PalestranteDto>
    {
        public SalvarPalestranteResult()
        {
        }

        public SalvarPalestranteResult(PalestranteDto result) : base(result)
        {
        }

        public SalvarPalestranteResult(IEnumerable<ApiError> errors) : base(errors)
        {
        }

        public SalvarPalestranteResult(params ApiError[] errors) : base(errors)
        {
        }

        public SalvarPalestranteResult(Exception ex) : base(ex)
        {
        }
    }
}
