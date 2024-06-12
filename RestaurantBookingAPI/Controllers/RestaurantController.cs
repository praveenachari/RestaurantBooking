using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantBookingAPI.Models;

namespace RestaurantBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        [HttpGet("reataurants")]
        [ProducesResponseType(200,Type=typeof(List<Restaurant>))]
        public async Task<ActionResult> GetAllRestaurant()
        {
            var restaurants = await _restaurantService.GetAllRestaurantsAsync();
            return Ok(restaurants);
        }
    }
}
