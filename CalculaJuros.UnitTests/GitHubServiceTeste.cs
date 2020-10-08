using CalculaJuros.API.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace CalcularJuros.UnitTests
{
  public class GitHubServiceTeste
  {
    [Fact]
    public void GetRepositoryUrlDefault()
    {
      var service = new GitHubService();

      string urlTemp = service.GetRepositoryUrl();

      Assert.AreEqual("https://github.com/snowfake/ShowMeTheCode", urlTemp);

    }
  }
}
