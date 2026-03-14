using Microsoft.EntityFrameworkCore;
using TetPee.Api.Middiewares;
using TetPee.Repository;
using TetPee.Service.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);// đăng ký dịch vụ truy xuất cho database và phải nạp thêm

builder.Services.AddScoped<IService, Service>();
builder.Services.AddTransient<GlobalExceptionHandlerMiddlewares>();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandlerMiddlewares>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();