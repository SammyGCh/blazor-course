using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppServer.Servicios.Interfaces
{
    public interface IServicioPersonajes
    {
        Task ObtenerPersonajes();
    }
}
