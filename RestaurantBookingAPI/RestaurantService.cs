﻿using RestaurantBookingAPI.Models;

namespace RestaurantBookingAPI
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _repository;
        public RestaurantService(IRestaurantRepository repository)
        {
            _repository = repository;
        }
        public Task<List<Restaurant>> GetAllRestaurantsAsync()
        {
            return _repository.GetAllRestaurantsAsync();
        }
    }
}
