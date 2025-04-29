using System.Text;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using AuthenticationExtentions;
using System.Reflection.Metadata.Ecma335;
using LoggerService;
using NLog;
using Contracts.Logger;
using CompanyEmployees.Extentions;
using Contracts.IRepositoy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Entities.Exceptions;


var builder = WebApplication.CreateBuilder(args);


// LogManager.LoadConfiguration("nlog.config");//nlog.config is detected automaticly

builder.Services.configureLoggerService();

builder.Services.configureRepositoryManager();

builder.Services.confiureServiceManager();

builder.Services.configureSqlContext(builder.Configuration);

builder.Services.AddControllers()
    .AddApplicationPart(typeof(CompanyEmployees.Presentation.AssemblyReference).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddJwtAuthentication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

// app.useAuthentication()
app.UseAuthorization();//useAuthentication also be default

app.UseCustomExceptionHandler();

app.MapControllers();


app.Run();

