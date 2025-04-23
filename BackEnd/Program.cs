using GestorMultiPessoas.Context;
using GestorMultiPessoas.Repository.Cadastro;
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


builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<EmpresaRepository>();
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
builder.Services.AddScoped<ISalarioRepository, SalarioRepository>();
builder.Services.AddScoped<IBeneficioRepository, BeneficioRepository>();

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

    // Configurar Swagger com um título personalizado
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Minha API Personalizada",
            Version = "v1",
            Description = "Documentação da API para o gerenciamento",
            Contact = new OpenApiContact
            {
                Name = "Suporte da API",
                Email = "suporte@email.com",
                Url = new Uri("https://minhaapi.com/suporte")
            },
            License = new OpenApiLicense
            {
                Name = "Licença MIT",
                Url = new Uri("https://opensource.org/licenses/MIT")
            }
        });

        // Adicionando autenticação JWT no Swagger
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Digite 'Bearer {seu token JWT}'"
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

var app = builder.Build();

// Configuração do pipeline HTTP
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API Personalizada v1");
        c.DocumentTitle = "Documentação da API - Dicionário de Dados"; // 🔹 Altera o título da aba do navegador
    });
}

app.UseHttpsRedirection();

app.UseAuthentication(); // 🔹 Ativar autenticação JWT
app.UseAuthorization();
app.MapControllers();
app.Run();
