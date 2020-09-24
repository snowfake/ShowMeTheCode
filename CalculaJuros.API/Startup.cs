using CalculaJuros.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CalculaJuros.API
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Calcula Juros API", Version = "v1" });
      });

      services.AddSingleton<IWebHostBuilder, WebHostBuilder>();

      services.AddHttpClient<ITaxaJurosService, TaxaJurosService>();

      services.AddScoped<ITaxaJurosService, TaxaJurosService>();
      services.AddScoped<ICalcularJurosService, CalcularJurosService>();
      services.AddScoped<IGitHubService, GitHubService>();
      services.AddSingleton<IIntegrateService, IntegrateService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Calcula Juros V1");
      });

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
      
    }
  }
}
