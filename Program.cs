
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftsPlayerApi.Json;
using SwiftsPlayerApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

// ✅ Add connection string + PostgreSQL
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


// ✅ fix
//var connectionString = builder.Configuration["DefaultConnection"];
//var connectionString = "Host=swiftsplayers.postgres.database.azure.com;Port=5432;Database=Swifts;Username=apiclient@swiftsplayers;Password=ApiTest123;Ssl Mode=Require;Trust Server Certificate=true;";

var connectionString = builder.Configuration["DefaultConnection"];

Console.WriteLine($"Loaded connection string: {connectionString}");


builder.Services.AddDbContext<SwiftsContext>(options =>
    options.UseNpgsql(connectionString));

// ✅ Register controllers and Swagger
//builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);  // v1.0
    options.ReportApiVersions = true;
});
builder.Services.Configure<JsonOptions>(options =>
{
    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
});


var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("[DEBUG] DefaultConnection = {ConnectionString}", connectionString);

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowAll");
app.MapControllers();

//Console.WriteLine($"[DEBUG] DefaultConnection = {connectionString}");


app.Run();





