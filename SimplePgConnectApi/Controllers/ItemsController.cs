using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Для ToListAsync()
using SimplePgConnectApi.Data;
using SimplePgConnectApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplePgConnectApi.Controllers
{
    [Route("api/[controller]")] // Маршрут: /api/items
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context; // Внедряем DbContext

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            // Просто получаем все записи из таблицы Items
            var items = await _context.Items.ToListAsync();
            return Ok(items); // Возвращаем список с кодом 200 OK
        }

        // POST: api/items
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            if (item == null || string.IsNullOrWhiteSpace(item.Name))
            {
                return BadRequest("Item name cannot be empty."); // Простая валидация
            }

            // Добавляем новый элемент в контекст EF Core
            _context.Items.Add(item);
            // Сохраняем изменения в базе данных
            await _context.SaveChangesAsync();

            // Возвращаем созданный элемент (с присвоенным Id) и кодом 201 Created
            // Для простоты вернем Ok с объектом
             return Ok(item);
            // Правильнее было бы вернуть CreatedAtAction, но для простоты оставим Ok
            // return CreatedAtAction(nameof(GetItems), new { id = item.Id }, item);
        }
    }
}