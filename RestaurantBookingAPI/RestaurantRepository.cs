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
        public async Task<List<Restaurant>> GetAllRestaurantsAsync()
        {
            var restaurants=await _dbContext.Restaurants.OrderBy(x=>x.Name).Select(r=>new Restaurant()
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
    }
}
