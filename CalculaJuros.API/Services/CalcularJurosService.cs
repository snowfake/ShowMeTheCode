using System;
using System.Threading.Tasks;

namespace CalculaJuros.API.Services
{
  public class CalcularJurosService : ICalcularJurosService
  {
    public ITaxaJurosService TaxaJurosService { get; }

    public CalcularJurosService(ITaxaJurosService taxaJurosService)
    {
      TaxaJurosService = taxaJurosService;
    }

    public async Task<decimal> CalcularJuros(int nroMeses, decimal valorInicial)
    {
      var taxaJuros = TaxaJurosService.GetTaxaJuros();

      return await CalcularJuros(nroMeses, valorInicial, taxaJuros.Result);
    }

    public async Task<decimal> CalcularJuros(int nroMeses, decimal valorInicial, decimal taxaJuros)
    {
      if (valorInicial == 0)
        return 0;

      var resultPotencia = Math.Pow(Convert.ToDouble(1 + taxaJuros), Convert.ToDouble(nroMeses));

      if (!decimal.TryParse(Convert.ToString(resultPotencia), out decimal resultPotenciaDecimal))
        throw new ApplicationException("Erro ao calcular os juros. Verifique o valor informado!");

      return Math.Truncate(Convert.ToDecimal(valorInicial * resultPotenciaDecimal) * 100) / 100;
    }
  }
}
