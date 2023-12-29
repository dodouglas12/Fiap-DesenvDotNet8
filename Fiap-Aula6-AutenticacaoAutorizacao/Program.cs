using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Fiap_Aula6_AutenticacaoAutorizacao.Interfaces;
using Fiap_Aula6_AutenticacaoAutorizacao.Middlewares;
using Fiap_Aula6_AutenticacaoAutorizacao.Repository;
using Fiap_Aula6_AutenticacaoAutorizacao.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ITokenService, TokenService>();
builder.Services.AddSingleton<IUsuarioRepository, UsuarioRepository>();

//** Nesse bloco estamos configurando a nossa aplicação para validar o nosso JWT em toda requisição **//
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("SecretJWT"));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
//** Nesse bloco estamos configurando a nossa aplicação para validar o nosso JWT em toda requisição **//

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//** Nesse bloco configuramos o swagger para nos possibilitar a inclusão do nosso JWT **//
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Aula 6 - Autenticação e Autorização", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description =
            "JWT Authorization Header - utilizado com Bearer Authentication.\r\n\r\n" +
            "Digite 'Bearer' [espaço] e então seu token no campo abaixo.\r\n\r\n" +
            "Exemplo (informar sem as aspas): 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
//** Nesse bloco configuramos o swagger para nos possibilitar a inclusão do nosso JWT **//

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseListaMemoriaMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
