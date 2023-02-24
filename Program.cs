using BookApi.DataAccess;
using BookApi.Helper;
using BookApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BookDbContext>();
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
using (var scope = app.Services.CreateScope())
{

    var db = scope.ServiceProvider.GetRequiredService<BookDbContext>();
    try
    {
        db.Database.Migrate();
        var services = scope.ServiceProvider;
        DataGenerator.Initialize(services);

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }

    var pendings = db.Database.GetPendingMigrations().ToList();

}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseLogging();
app.Run();
