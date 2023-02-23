using BookApi.DataAccess;
using BookApi.Helper;
using BookApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BookDbContext>();
//builder.Services.AddScoped(DataGenerator.Initialize());
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSingleton<ServiceResponse<Book>>();
//builder.Services.AddSingleton<IBook<Book>>();
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
app.UseLogging();
app.Run();
