

using Microsoft.EntityFrameworkCore;
using CRUD.Servicios.Implementacion;
using CRUD.Servicios.Contratos;
using CRUD.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<CrudbContext>(option => {
    _= option.UseMySQL(builder.Configuration.GetConnectionString("CrudbContext"));
    });
builder.Services.AddScoped<IServicioUsuario,ServicioUsuario>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Inicio}/{action=IniciarSesion}/{id?}");

app.Run();
