using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagementSystem.API.Models
{
    public class OrderMenuItem
    {
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        [ForeignKey("MenuItem")]
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; } = null!;
    }
}
