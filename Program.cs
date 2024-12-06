using Escalas.Components;
using Escalas.Components.Services;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;



var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<VoluntarioService>();
builder.Services.AddScoped<InstituicaoService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();

    builder.Services.AddHsts(options =>
    {
        options.Preload = true; // Permite pré-carregar HSTS no navegador
        options.IncludeSubDomains = true; // Aplica a subdomínios
        options.MaxAge = TimeSpan.FromDays(365); // Expira após 1 ano
    });
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
