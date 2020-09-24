using System.Threading.Tasks;

namespace CalculaJuros.API.Services
{
  public interface ICalcularJurosService
  {
    Task<decimal> CalcularJuros(int nroMeses, decimal valorInicial);
  }
}