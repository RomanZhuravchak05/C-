namespace RestaurantManagementSystem.API.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; } 
        public int TableId { get; set; }
        public List<int> MenuItemIds { get; set; } = new();
        public string? Status { get; set; } 
    }
}
