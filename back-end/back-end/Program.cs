using AutoMapper;
using back.Domain.Interfaces;
using back.Infrastructure.Context;
using back.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

//Configurando o banco
var connectionString = builder.Configuration.GetConnectionString("ApiServer");

// Configurando o DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString,
              assembly => assembly.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
});

//Configurando CORS
builder.Services.AddCors();

//Adicionando injeção de dependencias
builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IItensRepository, ItensRepository>();
builder.Services.AddScoped<ISolicitacoesRepository, SolicitacoesRepository>();

//Configurando autoMapper
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
