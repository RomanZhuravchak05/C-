namespace RestaurantManagementSystem.API.Models
{
    public class Table
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int Seats { get; set; }

        public bool IsReserved { get; set; } = false;
    }

}
