using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using talentbridge_webAPI.Interfaces;
using talentbridge_webAPI.Repositories;
using TalentBridge_webAPI.data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Configura a string de conex�o para o DbContext
builder.Services.AddDbContext<TalentBridgeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ICandidatoRepository, CandidatoRepository>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
builder.Services.AddScoped<IVagaRepository, VagaRepository>();
builder.Services.AddScoped<IAplicacaoRepository, AplicacaoRepository>();

// Configura��o do JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    // Par�metros de valida��o do JWT
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // Valida��o do emissor do token
        ValidateIssuer = true,
        ValidIssuer = "talentbridge_webapi",

        // Valida��o do p�blico do token
        ValidateAudience = true,
        ValidAudience = "talentbridge_webapi",

        // Valida��o da chave de assinatura do token
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sua_chave_secreta_de_32_bytes_de_tamanho_!!!")), // Sua chave secreta

        // Valida��o da expira��o do token
        ValidateLifetime = true,

        // Toler�ncia para expira��o
        ClockSkew = TimeSpan.FromMinutes(30)
    };

    // Se desejar, pode adicionar eventos customizados para falhas de autentica��o
    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            Console.WriteLine("Falha na autentica��o: " + context.Exception.Message);
            return Task.CompletedTask;
        },
        OnChallenge = context =>
        {
            context.HandleResponse(); // N�o propaga o erro
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddAuthorization(); // Necess�rio para habilitar a autoriza��o

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
}); ;

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    options.SwaggerEndpoint("/openapi/v1.json", "Talent Bridge API"));
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
