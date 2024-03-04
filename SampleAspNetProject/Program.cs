using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SampleAspNetProject.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// In memory sqlite databases are always transient for some reason so we have to do this to be able to call EnsureCreated() only once
var dbConnection = new SqliteConnection("DataSource=:memory:");
dbConnection.Open();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlite(dbConnection);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// A scope is needed for DatabaseContext to be created
using (var scope = app.Services.CreateScope())
{
    DatabaseContext db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    db.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
