using Microsoft.EntityFrameworkCore;
using AutoPartX.DAL.EF;
using AutoPartX.BLL.Services;
using AutoPartX.DAL.Repos; 

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<CategoryRepo>();
builder.Services.AddScoped<PartRepo>();


builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<PartService>();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers(); 


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers(); 

app.Run();