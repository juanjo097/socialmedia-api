using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Responses
{
    
    public class Response<T>
    {
        public Response( T data )
        {
            Data = data;
        }
        public T Data { get; set; }
    }
}
