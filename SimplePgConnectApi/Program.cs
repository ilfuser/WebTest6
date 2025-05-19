using Microsoft.EntityFrameworkCore; // Добавь using
using SimplePgConnectApi.Data;      // Добавь using

var builder = WebApplication.CreateBuilder(args);

// --- Добавь эти строки ---
// 1. Получаем строку подключения из конфигурации
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Регистрируем ApplicationDbContext как сервис
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString)); // Указываем, что используем PostgreSQL
// --- Конец добавленных строк ---

// Add services to the container. (Стандартный код)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline. (Стандартный код)
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Можно закомментировать для простоты локального тестирования без HTTPS

app.UseAuthorization();

app.MapControllers();

app.Run();