using WorkOne.DbAccess;
using WorkOne.DbAccess.Repository;
using WorkOne.DbAccess.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();


// подключение Контроллеров
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(opt =>
{
    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    opt.RoutePrefix = string.Empty;
});

// http -> https
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
