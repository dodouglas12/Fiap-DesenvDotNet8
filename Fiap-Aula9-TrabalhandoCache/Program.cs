using Fiap_Aula9_TrabalhandoCache.Interfaces;
using Fiap_Aula9_TrabalhandoCache.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ITesteCache, TesteCache>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Middleware responsável pela injeção do cache
builder.Services.AddMemoryCache();

var app = builder.Build();

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
