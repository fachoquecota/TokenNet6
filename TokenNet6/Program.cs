using TokenNet6.Business;
using TokenNet6.Data.StoreProcedures;
using TokenNet6.Interfaces;
using TokenNet6.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITokenNet, BusinessLogin>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ISprBusiness, StoredProcedureRepository>();
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
