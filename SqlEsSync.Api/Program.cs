using Microsoft.EntityFrameworkCore;
using SqlEsSync.Application.Messages.Queries;
using SqlEsSync.Domain.Interfaces;
using SqlEsSync.Domain.Sql;
using SqlEsSync.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SqlEsSyncContext>(
    (provider, options) =>
    {
        var configuration = provider.GetRequiredService<IConfiguration>();

        var connectionString = configuration.GetConnectionString("Sql");
        options.UseSqlServer(connectionString);
    });

builder.Services.AddScoped<IDistributorRepository, DistributorRepository>();

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssemblyContaining<GetDistributorById>();
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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
