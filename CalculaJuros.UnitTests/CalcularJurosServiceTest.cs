using CalculaJuros.API.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Xunit;


namespace CalculaJuros.UnitTests
{
  public class CalcularJurosServiceTest
  {
    [Fact]
    public void CalcularJuros_ResultadoEsperadoTest()
    {
      var jurosService = new CalcularJurosService(null);

      short nroMeses = 5;
      decimal valorInicial = 100;
      decimal taxaJuros = 0.01M;

      var result =  jurosService.CalcularJuros(nroMeses, valorInicial, taxaJuros).Result;

      Assert.AreEqual(105.10M, result);
    }

    [Fact]
    public void CalcularJuros_MesZeradoTest()
    {
      var jurosService = new CalcularJurosService(null);

      short nroMeses = 0;
      decimal valorInicial = 100;
      decimal taxaJuros = 0.01M;

      var result = jurosService.CalcularJuros(nroMeses, valorInicial, taxaJuros).Result;

      Assert.AreEqual(100M, result);
    }

    [Fact]
    public void CalcularJuros_ValorAltoTest()
    {
      var jurosService = new CalcularJurosService(null);

      short nroMeses = 90;
      decimal valorInicial = 100;
      decimal taxaJuros = 900M;

      Assert.ThrowsExceptionAsync<ApplicationException>(() => jurosService.CalcularJuros(nroMeses, valorInicial, taxaJuros));
    }

    [Fact]
    public void CalcularJuros_TodosValoresZeradosTest()
    {
      var jurosService = new CalcularJurosService(null);

      short nroMeses = 0;
      decimal valorInicial = 0;
      decimal taxaJuros = 0M;

      var result = jurosService.CalcularJuros(nroMeses, valorInicial, taxaJuros).Result;

      Assert.AreEqual(0M, result);
    }

    [Fact]
    public void CalcularJuros_TaxaJurosZeradoTest()
    {
      var jurosService = new CalcularJurosService(null);

      short nroMeses = 10;
      decimal valorInicial = 1000.50M;
      decimal taxaJuros = 0M;

      var result = jurosService.CalcularJuros(nroMeses, valorInicial, taxaJuros).Result;

      Assert.AreEqual(valorInicial, result);
    }

    [Fact]
    public void CalcularJuros_ValorInicialZeradoTest()
    {
      var jurosService = new CalcularJurosService(null);

      short nroMeses = 10;
      decimal valorInicial = 0M;
      decimal taxaJuros = 0.09M;

      var result = jurosService.CalcularJuros(nroMeses, valorInicial, taxaJuros).Result;

      Assert.AreEqual(0M, result);
    }

    [Fact(DisplayName ="Valor está sendo truncado")]
    public void CalcularJuros_ValorTruncadoTest()
    {
      var jurosService = new CalcularJurosService(null);

      short nroMeses = 9;
      decimal valorInicial = 100M;
      decimal taxaJuros = 0.01M;

      var result = jurosService.CalcularJuros(nroMeses, valorInicial, taxaJuros).Result;

      Assert.AreEqual(109.36M, result);  
    }
  }
}
