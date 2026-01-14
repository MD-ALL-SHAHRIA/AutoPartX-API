using Microsoft.EntityFrameworkCore;
using AutoPartX.DAL.EF;
using AutoPartX.DAL.Repos;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<CategoryRepo>();
builder.Services.AddScoped<PartRepo>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers(); 

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers(); 

app.Run();