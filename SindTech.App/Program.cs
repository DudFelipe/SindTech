using Microsoft.EntityFrameworkCore;
using SindTech.Business.Interfaces.Repositories;
using SindTech.Business.Interfaces.Services;
using SindTech.Business.Services;
using SindTech.Data.Context;
using SindTech.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(Program));

//Dependencias
builder.Services.AddScoped<DatabaseContext>();

builder.Services.AddScoped<IMoradorRepository, MoradorRepository>();
builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
builder.Services.AddScoped<IReclamacaoRepository, ReclamacaoRepository>();

builder.Services.AddScoped<IMoradorService, MoradorService>();
builder.Services.AddScoped<IContatoService, ContatoService>();
builder.Services.AddScoped<IReclamacaoService, ReclamacaoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
