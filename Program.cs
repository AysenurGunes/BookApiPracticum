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
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IBook<Book>, BookRepository<Book,BookDbContext>>();
builder.Services.AddScoped<IBook<BookType>, BookRepository<BookType, BookDbContext>>();
builder.Services.AddScoped<IBook<Publisher>, BookRepository<Publisher, BookDbContext>>();
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
