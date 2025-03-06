using LSC.RestaurantTableBookingApp.Core;
using Microsoft.EntityFrameworkCore;
namespace RestaurantBookingAPI.Data
{
    /// <summary>
    /// ctor is the snippet used to shortcut to create constructor
    /// </summary>
    public class RestaurantDbContext:DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options):base(options)
        {
            
        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<DiningTable> DiningTables { get; set; }
        public DbSet<RestaurantBranch> RestaurantBranches { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
