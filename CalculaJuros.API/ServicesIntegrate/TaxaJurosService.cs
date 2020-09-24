using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculaJuros.API.Services
{
  public class TaxaJurosService : ITaxaJurosService
  {
    public IHttpClientFactory ClientFactory { get; }
    public IIntegrateService IntegrateService { get; }

    public TaxaJurosService(IHttpClientFactory clientFactory, IIntegrateService integrateService)
    {
      ClientFactory = clientFactory;
      IntegrateService = integrateService;
    }

    public async Task<decimal> GetTaxaJuros()
    {
      try
      {
        string gatewayURL = IntegrateService.GetURLGateway();

        HttpClient client = ClientFactory.CreateClient("taxaJuros");

        client.BaseAddress = new Uri(gatewayURL);

        HttpResponseMessage result = await client.GetAsync(gatewayURL + "/taxajuros");

        decimal.TryParse(result.Content.ReadAsStringAsync().Result, out decimal taxaJuros);

        return taxaJuros;
      }
      catch (Exception e)
      {
        throw new Exception($"Erro ao buscar a taxa de juros. Erro: {e}");
      }
    }
  }
}
