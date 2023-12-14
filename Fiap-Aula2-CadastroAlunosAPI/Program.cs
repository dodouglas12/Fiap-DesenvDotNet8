using Fiap_Aula2_CadastroAlunosAPI.Implementations;
using Fiap_Aula2_CadastroAlunosAPI.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IAlunoCadastro, AlunoCadastro>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
