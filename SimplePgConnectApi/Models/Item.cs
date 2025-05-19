namespace SimplePgConnectApi.Models
{
    public class Item
    {
        public int Id { get; set; } // Первичный ключ (EF Core определит автоматически)
        public string Name { get; set; } = string.Empty; // Имя элемента
    }
}