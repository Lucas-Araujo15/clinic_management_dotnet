using clinic_management_dotnet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(
    c =>
    {
        c.EnableAnnotations();
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "API de Cadastro de Pacientes e Planos de Saúde\r\n",
            Description = "API em C# para gerenciar o cadastro de pacientes e planos\r\nde saúde de uma clínica, bem a relação entre pacientes e seus\r\nrespectivos planos.",
            License = new OpenApiLicense() { Name = "MIT License", Url = new Uri("https://opensource.org/licenses/MIT") }
        });
    }
);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

var MyAllowSpecificOrigins = "_AllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin();
                          policy.AllowAnyMethod();
                      });
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
