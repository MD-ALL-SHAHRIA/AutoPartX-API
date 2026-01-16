using AutoPartX.BLL.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<PartService>();
builder.Services.AddScoped<CategoryService>();

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