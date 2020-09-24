using CalculaJuros.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CalculaJuros.API.Controllers
{
  [Route("api/v1/[controller]")]
  [ApiController]
  public class CalculaJurosController : ControllerBase
  {
    public ICalcularJurosService CalcularJurosServices { get; }

    public CalculaJurosController(ICalcularJurosService calcularJurosServices)
    {
      CalcularJurosServices = calcularJurosServices;
    }

    // GET api/values
    [HttpGet("valorinicial/{valorInicial}/meses/{nroMeses}")]
    public async Task<ActionResult<decimal>> Get(int nroMeses, decimal valorInicial)
    {
      var result = await CalcularJurosServices.CalcularJuros(nroMeses, valorInicial);

      return Ok(result);
    }
  }
}
