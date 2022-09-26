using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppServer.Utilerias
{
    public interface IClienteHttp
    {
        Task<Response> PeticionGetAsync<Response>(string url);
    }
}
