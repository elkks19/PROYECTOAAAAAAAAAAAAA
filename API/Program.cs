using Microsoft.EntityFrameworkCore;
using API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<APIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection") ?? throw new InvalidOperationException("Connection string 'DBConnection' not found.")));

var misPoliticas = "misPoliticas";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: misPoliticas,
                      policy =>
                      {
                          policy.AllowAnyOrigin().
                          AllowAnyMethod().
                          AllowAnyHeader();
                      });
});

builder.Services.AddControllers().AddControllersAsServices();
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

app.UseCors(misPoliticas);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{cod?}"
    );

app.Run();
