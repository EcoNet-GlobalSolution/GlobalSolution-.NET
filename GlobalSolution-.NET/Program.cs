using GlobalSolution_.NET.Persistence;
using GlobalSolution_.NET.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<OracleDbContext>(o => o.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")).LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name }, LogLevel.Information));
builder.Services.AddScoped<ICoordenadasRepository, CoordenadasRepository>();
builder.Services.AddScoped<IDeteccaoRepository, DeteccaoRepository>();
builder.Services.AddScoped<IEspecieRepository, EspecieRepository>();
builder.Services.AddScoped<ITiporiscoRepository, TiporiscoRepository>();

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

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<OracleDbContext>();
    DbInitializer.Initialize(context);
}

app.Run();
