using Microsoft.EntityFrameworkCore;
using PersonApi.Data;
using PersonApi.Services;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<PersonneService>();


builder.Services.AddControllers();


var app = builder.Build();

//app.UseHttpsRedirection();

app.MapControllers();

app.Run();
