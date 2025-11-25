var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Ruta raíz para evitar error 404 - Página HTML visual
app.MapGet("/", () => Results.Content(@"
<!DOCTYPE html>
<html lang=""es"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>API Despliegue Final</title>
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            min-height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
            padding: 20px;
        }
        .container {
            background: white;
            border-radius: 20px;
            box-shadow: 0 20px 60px rgba(0, 0, 0, 0.3);
            padding: 40px;
            max-width: 600px;
            width: 100%;
            text-align: center;
        }
        h1 {
            color: #667eea;
            margin-bottom: 10px;
            font-size: 2.5em;
        }
        .subtitle {
            color: #666;
            margin-bottom: 30px;
            font-size: 1.1em;
        }
        .status {
            display: inline-block;
            background: #10b981;
            color: white;
            padding: 8px 20px;
            border-radius: 20px;
            font-weight: bold;
            margin-bottom: 30px;
        }
        .endpoints {
            text-align: left;
            background: #f8f9fa;
            border-radius: 10px;
            padding: 20px;
            margin-top: 20px;
        }
        .endpoints h2 {
            color: #333;
            margin-bottom: 15px;
            font-size: 1.3em;
        }
        .endpoint-item {
            background: white;
            padding: 15px;
            margin-bottom: 10px;
            border-radius: 8px;
            border-left: 4px solid #667eea;
            transition: transform 0.2s;
        }
        .endpoint-item:hover {
            transform: translateX(5px);
        }
        .endpoint-item strong {
            color: #667eea;
            display: block;
            margin-bottom: 5px;
        }
        .endpoint-item a {
            color: #667eea;
            text-decoration: none;
            font-weight: 600;
        }
        .endpoint-item a:hover {
            text-decoration: underline;
        }
        .footer {
            margin-top: 30px;
            color: #999;
            font-size: 0.9em;
        }
    </style>
</head>
<body>
    <div class=""container"">
        <h1> API Despliegue Final</h1>
        <p class=""subtitle"">API REST desplegada en Azure</p>
        <div class=""status""> En línea y funcionando correctamente</div>
        
        <div class=""endpoints"">
            <h2> Endpoints disponibles</h2>
            <div class=""endpoint-item"">
                <strong>Weather Forecast</strong>
                <a href=""/WeatherForecast"" target=""_blank"">/WeatherForecast</a>
                <p style=""color: #666; font-size: 0.9em; margin-top: 5px;"">Obtiene el pronóstico del tiempo</p>
            </div>
        </div>
        
        <div class=""footer"">
            <p>Desplegado en Azure App Service</p>
        </div>
    </div>
</body>
</html>
", "text/html"));

app.MapControllers();

app.Run();
