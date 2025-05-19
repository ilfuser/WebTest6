using Microsoft.EntityFrameworkCore;
using SimplePgConnectApi.Models; // Не забудь добавить using для модели

namespace SimplePgConnectApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Конструктор, принимающий опции (нужен для конфигурации в Program.cs)
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet представляет таблицу "Items" в базе данных
        public DbSet<Item> Items { get; set; }
    }
}