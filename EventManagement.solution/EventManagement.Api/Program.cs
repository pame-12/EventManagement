using EventManagement.Api.Interfaces;
using EventManagement.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.
builder.Services.AddControllers();

// Registrar la interfaz y su implementaci�n.
builder.Services.AddScoped<IEventService, EventService>();

// Configuraci�n de Swagger para documentaci�n.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar la tuber�a HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


