using Escalas.Migrations;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Charts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Escalas.Components
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Voluntario> Voluntarios { get; set; }

        //dotnet ef migrations add InitialCreate

        //dotnet ef database update
    }

}
