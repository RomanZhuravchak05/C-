namespace RestaurantManagementSystem.API.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public decimal Price { get; set; }

        public ICollection<OrderMenuItem> OrderMenuItems { get; set; } = new List<OrderMenuItem>();
    }
}
