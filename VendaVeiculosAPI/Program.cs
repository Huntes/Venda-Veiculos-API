using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using VendaVeiculosAPI.Repositories;
using VendaVeiculosAPI.Utils;
using Microsoft.EntityFrameworkCore;
using VendaVeiculosAPI.Services;
using AutoMapper;
using AutoMapper.Internal;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Configuração de swagger para documentação de API e autenticação JWT
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });


    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer",
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

#region DependencyInjection
SettingDI();
builder.Services.AddDbContext<Context>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
    ));
#endregion

#region Autenticacao JWT
builder.Services.AddAuthentication(c =>
{
    c.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    c.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(c =>
{
    c.RequireHttpsMetadata = false;
    c.SaveToken = true;
    c.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key._secretKey)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
#endregion

#region AutoMapperConfig
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

JsonConvert.DefaultSettings = () => new JsonSerializerSettings
{ 
    NullValueHandling = NullValueHandling.Ignore,
    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
    ContractResolver = new CamelCasePropertyNamesContractResolver()
};

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VendaVeiculosAPI v1"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void SettingDI()
{
    builder.Services.AddRepository();
    builder.Services.AddServices();
}