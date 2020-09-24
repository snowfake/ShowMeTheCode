using Microsoft.AspNetCore.Mvc;
using TaxaJuros.API.Services;

namespace TaxaJuros.API.Controllers
{
  [Route("api/v1/[controller]")]
  [ApiController]
  public class TaxaJurosController : ControllerBase
  {
    public ITaxaJurosServices TaxaJurosServices { get; }

    public TaxaJurosController(ITaxaJurosServices taxaJurosServices)
    {
      TaxaJurosServices = taxaJurosServices;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<decimal> Get()
    {
      return Ok(TaxaJurosServices.GetTaxaJuros());
    }

  }
}
