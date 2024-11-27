using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApi.DAL;
using WebApi.Domain.Interfaces;
using WebApi.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Línea de código que necesito para configurar la conexion a la base de datos.
builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//Contenedor de dependencias
builder.Services.AddScoped<ICountryService, CountryService>(); //Creando el servicio para poder ser utilizado en el controlador
builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddTransient<SeederDB>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

SeederData();

void SeederData()
{
    IServiceScopeFactory? scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();

    using (IServiceScope? scope = scopeFactory.CreateScope())
    {
        SeederDB? service = scope.ServiceProvider.GetService<SeederDB>();
        service.SeederAsync().Wait();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
