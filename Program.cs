using Chapter.WebApi.Contexts;
using Chapter.WebApi.Repositories;
using Microsoft.IdentityModel.Tokens;
using ChapterWebApi.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer; // Adicionado para usar o esquema padrão

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// FORMA DE AUTENTICAÇÃO ATUALIZADA PARA O PADRÃO DE MERCADO
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // Define "Bearer"
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;    // Define "Bearer"
})
// Parâmetros de validação do token vinculados ao padrão correto.
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // Valida quem está solicitando.
        ValidateIssuer = true,

        // Valida quem está recebendo.
        ValidateAudience = true,

        // Define se o tempo de expiração será validado.
        ValidateLifetime = true,

        // Validação da chave de autenticação (idêntica ao Controller).
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("WebApi-chave-autenticacao-segura-com-trinta-e-dois-caracteres")),

        // Tolerância de tempo para expiração do token.
        ClockSkew = TimeSpan.Zero, // Alterado para Zero para maior segurança de tempo real
        
        ValidIssuer = "WebApi.webapi",
        
        ValidAudience = "WebApi.webapi"
    };
});

// Configurações de Ciclo de Vida das Dependências
builder.Services.AddScoped<ChapterContext>();
builder.Services.AddTransient<LivroRepository>();

// CORREÇÃO: Removida a duplicidade. Mantido apenas um único registro Scoped para o repositório
builder.Services.AddScoped<UsuarioRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilita a Autenticação e Autorização nos middlewares (A ordem importa!)
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
