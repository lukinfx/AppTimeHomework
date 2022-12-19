using HomeworkAppTime;
using HomeworkAppTime.Services;
using HomeworkAppTime.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IFileLoaderService, FileLoaderService>();
builder.Services.AddScoped<IFileWriterService, FileWriterService>();
builder.Services.AddScoped<IFileNameService, FileNameService>();
builder.Services.AddScoped<IConvertService, ConvertService>();


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
