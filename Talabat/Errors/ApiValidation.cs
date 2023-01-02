using System.Collections;
using System.Collections.Generic;

namespace Talabat.Errors
{
    public class ApiValidationRespons : Api_Response
    {
        public IEnumerable<string> Errors { get; set; }
        public ApiValidationRespons():base(400)
        {
                
        }
    }
}
