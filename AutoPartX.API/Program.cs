using Microsoft.EntityFrameworkCore;
using AutoPartX.DAL.EF;
using AutoPartX.BLL.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<PartService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers(); 

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers(); 

app.Run();