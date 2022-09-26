using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorAppServer.Utilerias
{
    public class ClienteHttp : IClienteHttp
    {
        private readonly HttpClient _cliente;
        private HttpResponseMessage _httpResponseMessage;

        public ClienteHttp(HttpClient cliente)
        {
            _cliente = cliente;
        }

        public async Task<Response> PeticionGetAsync<Response>(string url)
        {
            Response respuesta;
            try
            {
                _httpResponseMessage = await _cliente.GetAsync(url);

                if (!_httpResponseMessage.IsSuccessStatusCode)
                {
                    throw new Exception("No se pudo conectar al servicio.");
                }

                string respuestaJson = await _httpResponseMessage.Content.ReadAsStringAsync();

                respuesta = JsonConvert.DeserializeObject<Response>(respuestaJson);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }
    }
}
