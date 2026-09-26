using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NSHub.Application;
using NSHub.Domain;
using NSHub.Infrastructure;
using NSHub.WebApi.Middleware;


// 1. Dependency Injection Configuration
builder.Services.AddDomainServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

// 2. Web API & Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
 