var builder = WebApplication.CreateBuilder(args);

// Configurar servicios
builder.Services.AddControllers(); // Agrega soporte para controladores
builder.Services.AddEndpointsApiExplorer(); // Habilita la exploración de endpoints para Swagger
builder.Services.AddSwaggerGen(); // Configura Swagger para la documentación

// Construir aplicación
var app = builder.Build();

// Configuración del pipeline de middleware
if (app.Environment.IsDevelopment())
{
    // Habilita Swagger y la interfaz de usuario de Swagger solo en el entorno de desarrollo
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Redirecciona automáticamente a HTTPS si se usa HTTP
app.UseAuthorization(); // Configura la autorización

// Configura las rutas de los controladores
app.MapControllers();

// Ejecutar la aplicación
app.Run();

