using SistemaMedico.Context;

var builder = WebApplication.CreateBuilder(args);

SistemaContexto contexto = new SistemaContexto();

// Add services to the container.

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

contexto.Database.EnsureCreated();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
