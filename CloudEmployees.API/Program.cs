using Microsoft.EntityFrameworkCore;
using CloudEmployees.DataAccess;
using CloudEmployees.DataAccess.DataContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder.Configuration["DefaultConnection"];
var serverVersion = new MySqlServerVersion(new Version(8,0,27));
builder.Services.AddDbContext<CloudEmployeesContext>(options => {
	options.UseMySql(serverVersion)
				// Following options should be delete on production environment.
				 .LogTo(Console.WriteLine, LogLevel.Information)
				 .EnableSensitiveDataLogging()
				 .EnableDetailedErrors();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
