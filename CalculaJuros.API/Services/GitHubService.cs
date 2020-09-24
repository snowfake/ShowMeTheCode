namespace CalculaJuros.API.Services
{
  public class GitHubService : IGitHubService
  {
    public string GetRepositoryUrl()
    {
      return "https://github.com/snowfake/ShowMeTheCode";
    }

  }
}
