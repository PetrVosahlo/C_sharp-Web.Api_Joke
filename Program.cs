using Microsoft.EntityFrameworkCore;
using Web.Api_Joke;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();// zaji��uje dependenci injection - vytv��� instance controler�
// , nen� t�eba je tvo�it JM_CONTROLLER JM_INSTANCE = new JM_CONTROLLER();
// dependenci injection == vytv��en� instanc� t��dy bez deklarace new JM_T��DY
// instance vytvo�en� dependenci injection existuje jen po dobu kdy je pot�eba a pak se automaticky zru��
// v�hoda: takov� instance m��e vyu��vat metody t��dy, dle p�i psan� programu u�et��m "= new JM_T��DY();"
builder.Services.AddDbContext<JokesDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Klic")));
//Builder.Services.AddDbContext<JokesDbContext> == sd�len� syst�m aby vytv��el instance JokesDbContext pomoc� dependeci injection
// .AddDbContext nahrazuje "new", options nahrazuje metodu OnConfiguring() p�i p�ipojov�n� do datab�ze
// .Configuration �te z appsettings.json conection string. Vyhled� "ConnectionStrings" -> "Klic"
// p�e�te z n�j "Data Source", "Initial Catalog", atd.
//Je pot�eba p�idat using Microsoft.EntityFrameworkCore; using Web.API; 
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
