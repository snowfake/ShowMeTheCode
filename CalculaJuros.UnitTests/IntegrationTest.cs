using CalculaJuros.API;
using CalculaJuros.API.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CalculaJuros.UnitTests
{
  public class IntegrationTest
  {
    private HttpClient ClientTaxaJuros { get; }
    public WebApplicationFactory<TaxaJuros.API.Startup> FactoryTaxaJuros { get; }
    private IIntegrateService IntegrateService { get; }

    public IntegrationTest(WebApplicationFactory<Startup> factory, WebApplicationFactory<TaxaJuros.API.Startup> factoryTaxaJuros, IIntegrateService integrateService)
    {
      ClientTaxaJuros = factoryTaxaJuros.CreateClient();
      FactoryTaxaJuros = factoryTaxaJuros;
      IntegrateService = integrateService;
    }

    [Fact]
    public async Task CanGetTaxaJuros()
    {
      // The endpoint or route of the controller action.
      var httpResponse = await ClientTaxaJuros.GetAsync(IntegrateService.GetURLGateway() + "/taxajuros");

      // Must be successful.
      httpResponse.EnsureSuccessStatusCode();

      // Deserialize and examine results.
      var stringResponse = await httpResponse.Content.ReadAsStringAsync();

      Assert.AreEqual("0.01", stringResponse);
    }
  }
}
