using Microsoft.EntityFrameworkCore;
using Odin.Data.Database;
using Odin.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Config da ConectionString
builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<OdinDBContex>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
    );

//Config da Injeção de dependecia
builder.Services.AddScoped<ITicketService, TicketService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

// Configuração do Cors
app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
