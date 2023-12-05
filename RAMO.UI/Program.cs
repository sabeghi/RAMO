using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RAMO.Application.Handlers.CommandHandlers;
using RAMO.Core.Repositories.Command.Base;
using RAMO.Core.Repositories.Query;
using RAMO.Core.Repositories.Query.Base;
using RAMO.Infrastructure.Data;
using RAMO.Infrastructure.Repositories.Command;
using RAMO.Infrastructure.Repositories.Command.Base;
using RAMO.Infrastructure.Repositories.Query;
using RAMO.Infrastructure.Repositories.Query.Base;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAntiforgery(option =>
{
    option.HeaderName = "XSRF-TOKEN";
});

builder.Services.AddControllers();

builder.Services.AddDbContext<RAMOContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RAMO.api", Version = "v1" });
});

// Register dependencies
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(CreateCustomerHandler).Assembly));
builder.Services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
builder.Services.AddTransient<ICustomerQueryRepository, CustomerQueryRepository>();
builder.Services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
builder.Services.AddTransient<RAMO.Core.Repositories.Command.ICustomerCommandRepository, CustomerCommandRepository>();



var app = builder.Build();

app.UseHttpsRedirection();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseAuthorization();

app.MapRazorPages();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RAMO.API v1");
        c.RoutePrefix = string.Empty;
    });
}
app.Run();
