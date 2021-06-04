using Microsoft.EntityFrameworkCore;
using VxTel.Entities.Entities;

namespace VxTel.Infra.Configuration
{
  public class ContextBase : DbContext
  {

    public ContextBase(DbContextOptions<ContextBase> options) : base(options)
    {
      Database.EnsureCreated();

      var cidade = Cidade.FirstOrDefaultAsync().Result;
      var tarifa = Tarifa.FirstOrDefaultAsync().Result;
      var plano = Plano.FirstOrDefaultAsync().Result;

      if (cidade == null)
      {
        Cidade.Add(new Cidade { Nome = "São Paulo", Codigo = "011" });
        Cidade.Add(new Cidade { Nome = "Ribeirão Preto", Codigo = "016" });
        Cidade.Add(new Cidade { Nome = "São José do Rio Preto", Codigo = "017" });
        Cidade.Add(new Cidade { Nome = "Presidente Prudente", Codigo = "018" });
      }

      if (tarifa == null)
      {
        Tarifa.Add(new Tarifa { Origem = "011", Destino = "016", Valor = 1.90 });
        Tarifa.Add(new Tarifa { Origem = "016", Destino = "011", Valor = 2.90 });
        Tarifa.Add(new Tarifa { Origem = "011", Destino = "017", Valor = 1.70 });
        Tarifa.Add(new Tarifa { Origem = "017", Destino = "011", Valor = 2.70 });
        Tarifa.Add(new Tarifa { Origem = "011", Destino = "018", Valor = 0.90 });
        Tarifa.Add(new Tarifa { Origem = "018", Destino = "011", Valor = 1.90 });
      }

      if (plano == null)
      {
        Plano.Add(new Plano { Nome = "FaleMais 30", Minutos = 30 });
        Plano.Add(new Plano { Nome = "FaleMais 60", Minutos = 60 });
        Plano.Add(new Plano { Nome = "FaleMais 120", Minutos = 120 });
      }

      SaveChanges();
    }

    public DbSet<Cidade> Cidade { get; set; }
    public DbSet<Plano> Plano { get; set; }
    public DbSet<Tarifa> Tarifa { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
        optionsBuilder.UseSqlServer(GetStringConectionConfig());
      base.OnConfiguring(optionsBuilder);
    }

    private string GetStringConectionConfig()
    {
      string strCon = "Server=(localdb)\\mssqllocaldb;Database=vxtel;Trusted_Connection=True;MultipleActiveResultSets=true";
      return strCon;
    }
  }
}
