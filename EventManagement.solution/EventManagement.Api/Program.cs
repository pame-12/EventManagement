var builder = WebApplication.CreateBuilder(args);

// Configurar servicios
builder.Services.AddControllers(); // Agrega soporte para controladores
builder.Services.AddEndpointsApiExplorer(); // Habilita la exploraci�n de endpoints para Swagger
builder.Services.AddSwaggerGen(); // Configura Swagger para la documentaci�n

// Construir aplicaci�n
var app = builder.Build();

// Configuraci�n del pipeline de middleware
if (app.Environment.IsDevelopment())
{
    // Habilita Swagger y la interfaz de usuario de Swagger solo en el entorno de desarrollo
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Redirecciona autom�ticamente a HTTPS si se usa HTTP
app.UseAuthorization(); // Configura la autorizaci�n

// Configura las rutas de los controladores
app.MapControllers();

// Ejecutar la aplicaci�n
app.Run();

