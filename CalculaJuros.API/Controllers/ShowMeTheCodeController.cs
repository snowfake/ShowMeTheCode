using CalculaJuros.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalculaJuros.API.Controllers
{
  [Route("api/v1/[controller]")]
  [ApiController]
  public class ShowMeTheCodeController : ControllerBase
  {
    public IGitHubService GitHubService { get; }
    public ShowMeTheCodeController(IGitHubService gitHubService)
    {
      GitHubService = gitHubService;
    }

    [HttpGet]
    public ActionResult<string> Get()
    {
      return Ok(this.GitHubService.GetRepositoryUrl());
    }
  }
}