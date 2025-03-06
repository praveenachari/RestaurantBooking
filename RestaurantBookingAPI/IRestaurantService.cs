using RestaurantBookingAPI.Models;

namespace RestaurantBookingAPI
{
    public interface IRestaurantService
    {
        Task<List<RestaurantModel>> GetAllRestaurantsAsync();
    }
}
