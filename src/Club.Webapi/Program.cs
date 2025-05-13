using Club.Application.Services;
using Club.Domain.Interfaces;
using Club.Infrastructure.Data;
using Club.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "Club API", Version = "v1" });
});

// EF Core DbContext
builder.Services.AddDbContext<ClubContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Repositories
builder.Services.AddScoped<IMemberRepository, MemberRespository>();

// Services
builder.Services.AddScoped<MemberService>();


var app = builder.Build();

// Configure Swagger.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Club API v1");
        c.RoutePrefix = "swagger";
    });

    app.Use(async (context, next) =>
    {
        if (context.Request.Path == "/")
        {
            context.Response.Redirect("/swagger");
            return;
        }

        await next();
    });
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();