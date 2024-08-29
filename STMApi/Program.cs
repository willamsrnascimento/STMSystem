using STMApi.Endpoints;
using Microsoft.EntityFrameworkCore;
using STMData;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSqlServer<STMDbContext>(builder.Configuration["Database:ConnectionString"]);

// Add services to the container.
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
app.EndpointConfigure();

app.Run();
