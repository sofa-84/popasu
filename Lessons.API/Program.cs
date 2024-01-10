using Lessons.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Lessons.Infrastructure.Repository.Realization;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddDbContext<LessonsDbContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("LessonsContext")));

builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<ILessonService, LessonService>();


// для фронтенда
builder.Services.AddCors(options =>
{
    options.AddPolicy("any", policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                       ForwardedHeaders.XForwardedProto
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("any");
app.UseAuthorization();
app.MapControllers();

app.Run();