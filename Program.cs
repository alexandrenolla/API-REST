using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using RESTful_API.Context;
using RESTful_API.Repositories;
using RESTful_API.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddFluentValidation(options =>
  {
     // Validate child properties and root collection elements
     options.ImplicitlyValidateChildProperties = true;
     options.ImplicitlyValidateRootCollectionElements = true;

     // Automatic registration of validator in assembly
     options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
  });




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção de dependência dos Repositórios e Interfaces
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<IAtendimentoRepository, AtendimentoRepository>();
builder.Services.AddScoped<IPedagogoRepository, PedagogoRepository>();
builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();

// Injeção de dependência do contexto
builder.Services.AddDbContext<LabSchoolContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("LabSchoolContext")));

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
