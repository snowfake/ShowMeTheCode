using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculaJuros.API.Services
{
  public class IntegrateService : IIntegrateService
  {
    public IConfiguration Configuration { get; }

    public IntegrateService(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public string GetURLGateway()
    {
      try
      {
        string gatewayURL = Configuration.GetValue<string>("GatewayURL");

        if (string.IsNullOrEmpty(gatewayURL))
          throw new ArgumentNullException("GatewayURL não foi informado");

        if(!Uri.IsWellFormedUriString(gatewayURL, UriKind.Absolute))
          throw new ApplicationException("GatewayURL informado não está em um formatato válido. Verifique a URL");

        return gatewayURL;
      }
      catch (Exception e)
      {
        throw new ApplicationException($"Erro ao buscar a URL do Gateway. Erro: {e}");
      }
    }
  }
}
