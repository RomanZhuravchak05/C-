using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagementSystem.API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }

        public List<OrderMenuItem> OrderMenuItems { get; set; } = new();
    }
}
