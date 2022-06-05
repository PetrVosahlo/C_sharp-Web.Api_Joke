using Microsoft.EntityFrameworkCore;
using Web.Api_Joke;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();// zaji¹»uje dependenci injection - vytváøí instance controlerù
// , není tøeba je tvoøit JM_CONTROLLER JM_INSTANCE = new JM_CONTROLLER();
// dependenci injection == vytváøení instancí tøídy bez deklarace new JM_TØÍDY
// instance vytvoøená dependenci injection existuje jen po dobu kdy je potøeba a pak se automaticky zru¹í
// výhoda: taková instance mù¾e vyu¾ívat metody tøídy, dle pøi psaní programu u¹etøím "= new JM_TØÍDY();"
builder.Services.AddDbContext<JokesDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Klic")));
//Builder.Services.AddDbContext<JokesDbContext> == sdìlení systém aby vytváøel instance JokesDbContext pomocí dependeci injection
// .AddDbContext nahrazuje "new", options nahrazuje metodu OnConfiguring() pøi pøipojování do databáze
// .Configuration ète z appsettings.json conection string. Vyhledá "ConnectionStrings" -> "Klic"
// pøeète z nìj "Data Source", "Initial Catalog", atd.
//Je potøeba pøidat using Microsoft.EntityFrameworkCore; using Web.API; 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());

app.UseAuthorization();

app.MapControllers();

app.Run();
