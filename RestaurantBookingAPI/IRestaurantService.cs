using RestaurantBookingAPI.Models;

namespace RestaurantBookingAPI
{
    public interface IRestaurantService
    {
        Task<List<Restaurant>> GetAllRestaurantsAsync();
    }
}
