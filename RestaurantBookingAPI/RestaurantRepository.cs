using Microsoft.EntityFrameworkCore;
using RestaurantBookingAPI.Data;
using RestaurantBookingAPI.Models;

namespace RestaurantBookingAPI
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantRepository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<RestaurantModel>> GetAllRestaurantsAsync()
        {
            var restaurants=await _dbContext.Restaurants.OrderBy(x=>x.Name).Select(r=>new RestaurantModel()
            {
                Id = r.Id,
                Name = r.Name,
                Address = r.Address,
                Phone = r.Phone,
                Email = r.Email,
                ImageUrl = r.ImageUrl
            }).ToListAsync();
            return restaurants;
        }

       /* public async Task<IEnumerable<DiningTableWithTimeSlotsModel>> GetDiningTableByBranchAsync(int branchId, DateTime date)
        {
           var diningTables = _dbContext.DiningTables.Where(dt => dt.RestaurantBranchId == branchId).SelectMany(dt => dt.TimeSlots, (dt, ts) => new
           {
               dt.RestaurantBranchId,
               dt.TableName,
               dt.Capacity,
               ts.ReservationDay,
               ts.MealType,
               ts.TableStatus,
               ts.Id
           }).Where(ts => ts.ReservationDay.Date == date.Date)
             .OrderBy(ts => ts.Id)
             .ThenBy(ts => ts.MealType)
             .ToListAsync();
            return diningTables.Select(dt => new DiningTableWithTimeSlotsModel
            {
                BranchId = dt.RestaurantBranchId,
                ReservationDay = dt.ReservationDay.Date,
                TableName = dt.TableName,
                Capacity = dt.Capacity,
                MealType = dt.MealType,
                TableStatus = dt.TableStatus,
                TimeSlotId = dt.Id
            });
        }
*/
        public Task<IEnumerable<DiningTableWithTimeSlotsModel>> GetDiningTableByBranchAsync(int branchId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RestaurantBranchModel>> GetRestaurantBranchesByRestaturantIdAsync(int restaurantId)
        {
            var branches = await _dbContext.RestaurantBranches.Where(rb=> rb.RestaurantId == restaurantId).Select(rb=>new RestaurantBranchModel
            {
                Id = rb.Id,
                RestaurantId = rb.RestaurantId,
                Name = rb.Name,
                Address = rb.Address,
                Phone = rb.Phone,
                Email = rb.Email,
                ImageUrl = rb.ImageUrl
            }).ToListAsync();
            return branches;
        }
    }
}
