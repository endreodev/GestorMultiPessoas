using GestorMultiPessoas.Context; 
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Configuração JWT
// 🔹 Pegamos a chave secreta do appsettings.json
var secretKey = builder.Configuration["JwtSettings:Secret"];
var key = Encoding.ASCII.GetBytes(secretKey?? "");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Adicionar autenticação e autorização
builder.Services.AddAuthorization();


// Configurar Kestrel para HTTP/2 e definir portas manualmente
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5001, listenOptions =>
    {
        listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2;
    });

    options.ListenAnyIP(5002, listenOptions =>
    {
        listenOptions.UseHttps();
        listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2;
    });
});

// Configurar a conexão com MySQL
var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Adicionar serviços
//builder.Services.AddControllers();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true; // Para melhor legibilidade
        //options.JsonSerializerOptions.ReferenceHandler = null; // Remove Preserve
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.WriteIndented = true; // Mantém JSON formatado

    });

    //// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    //builder.Services.AddSwaggerGen();

    // Configurar Swagger com múltiplas documentações
    builder.Services.AddSwaggerGen(c =>
    {
        // Authentication API Documentation
        c.SwaggerDoc("auth", new OpenApiInfo
        {
            Title = "Authentication API",
            Version = "v1",
            Description = "API endpoints for authentication and authorization",
            Contact = new OpenApiContact
            {
                Name = "Suporte da API",
                Email = "suporte@email.com",
                Url = new Uri("https://minhaapi.com/suporte")
            }
        });

        // Registration API Documentation
        c.SwaggerDoc("cadastros", new OpenApiInfo
        {
            Title = "Registration API",
            Version = "v1",
            Description = "API endpoints for managing registrations and entities"
        });

        // Payroll API Documentation
        c.SwaggerDoc("folha", new OpenApiInfo
        {
            Title = "Payroll API",
            Version = "v1",
            Description = "API endpoints for payroll management"
        });

        // Reports API Documentation
        c.SwaggerDoc("relatorios", new OpenApiInfo
        {
            Title = "Reports API",
            Version = "v1",
            Description = "API endpoints for reports generation"
        });

        // Integrations API Documentation
        c.SwaggerDoc("integracoes", new OpenApiInfo
        {
            Title = "Integrations API",
            Version = "v1",
            Description = "API endpoints for external integrations"
        });

        // Configure JWT Authentication
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Enter 'Bearer' [space] and then your token in the text input below.\n\nExample: 'Bearer 12345abcdef'"
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
                new string[] {}
            }
        });
    });

// Enable Swagger middleware
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/auth/swagger.json", "Autenticação API v1");
        c.SwaggerEndpoint("/swagger/cadastros/swagger.json", "Cadastros API v1");
        c.SwaggerEndpoint("/swagger/folha/swagger.json", "Folha API v1");
        c.SwaggerEndpoint("/swagger/relatorios/swagger.json", "Relatórios API v1");
        c.SwaggerEndpoint("/swagger/integracoes/swagger.json", "Integrações API v1");
    });
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
