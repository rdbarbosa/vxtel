using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VxTel.Application;
using VxTel.Application.Interfaces;
using VxTel.Domain.Interfaces.Entities;
using VxTel.Domain.Interfaces.Generics;
using VxTel.Infra.Configuration;
using VxTel.Infra.Repositories;

namespace VxTel.App
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
        services.AddCors(options =>
        {
        options.AddDefaultPolicy(
                    builder => builder.WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.IgnoreNullValues = true);    
        services.AddSwaggerGen();

        // configure strongly typed settings object
        //services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

        // configure DI for application services
        services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGenerics<>));

        services.AddSingleton<ICidade, RepositoryCidade>();
        services.AddSingleton<ICidadeService, CidadeService>();

        services.AddSingleton<IPlano, RepositoryPlano>();
        services.AddSingleton<IPlanoService, PlanoService>();

        services.AddSingleton<ITarifa, RepositoryTarifa>();
        services.AddSingleton<ITarifaService, TarifaService>();

        services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "VxTel API"));
      }

      app.UseCors();

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
