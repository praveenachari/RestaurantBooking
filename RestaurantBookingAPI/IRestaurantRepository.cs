using RestaurantBookingAPI.Models;

namespace RestaurantBookingAPI
{
    public interface IRestaurantRepository
    {
        Task<List<RestaurantModel>> GetAllRestaurantsAsync();
        Task<IEnumerable<RestaurantBranchModel>> GetRestaurantBranchesByRestaturantIdAsync(int restaurantId);
        //Task<IEnumerable<DiningTableWithTimeSlotModel>> GetDiningTableByBranchAsync(int branchId,DateTime date);
        //Task<IEnumerable<DiningTableWithTimeSlotModel>> GetDiningTableByBranchAsync(int branchId);

    }
}
