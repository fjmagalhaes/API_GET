using Chapter.WebApi.Contexts;
using Chapter.WebApi.Repositories;
using ChapterWebApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<ChapterContext>();
builder.Services.AddTransient<LivroRepository>();
builder.Services.AddTransient<UsuarioRepository, UsuarioRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();