using RestaurantBookingAPI.Models;

namespace RestaurantBookingAPI
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetAllRestaurantsAsync();
        Task<List<RestaurantBranch>> GetRestaurantBranchesByRestaturantIdAsync(int reataurantId);
        Task<IEnumerable<DiningTable>> GetDiningTableByBranchAsync(int restaurantId);

    }
}
