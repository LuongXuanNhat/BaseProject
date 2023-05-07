using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ViewModels.Common
{
    public class ApiErrorResult<T> : ApiResult<T>
    {
        public string[] ValidationErrors { get; set; }

        public ApiErrorResult()
        {
            // Trả về cái Null :)
        }
        public ApiErrorResult(string message)
        {
            IsSuccessed = false;
            Message = message;
        }

        public ApiErrorResult(string[] validationErrors)
        {
            IsSuccessed = false;
            ValidationErrors = validationErrors;
        }
    }
}
