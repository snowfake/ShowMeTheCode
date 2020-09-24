using System.Threading.Tasks;

namespace CalculaJuros.API.Services
{
  public interface ITaxaJurosService
  {
    Task<decimal> GetTaxaJuros();
  }
}
