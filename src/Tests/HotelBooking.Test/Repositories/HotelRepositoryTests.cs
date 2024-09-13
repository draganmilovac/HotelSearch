using Hotel.Infrastructure.Repositories;
using HotelBooking.Test.Lists;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Test.Repositories
{
    public class HotelRepositoryTests
    {
        #region Private fields
        private readonly Mock<ILogger<HotelRepository>> _mockLogger;
        private readonly HotelLists _hotelLists;
        #endregion

        #region Constructors
        public HotelRepositoryTests()
        {
            _mockLogger = new Mock<ILogger<HotelRepository>>();
            _hotelLists = new HotelLists();
        }
        #endregion

        #region Test methods
        [Fact]
        public async Task CreateHotelAsync_ShouldPopulateListAndReturnId()
        {
            HotelData.Models.Hotel hotel = new HotelData.Models.Hotel()
            {
                Name = "Hotel 5",
                Price = 60,
                Latitude = 46.257907355517624,
                Longitude = 20.81236695106882
            };
            var hotelRepository = new HotelRepository(_hotelLists.Hotels, _mockLogger.Object);
            var result = await hotelRepository.CreateAsync(hotel);
            Assert.Equal(5, result);
        }
        #endregion
    }
}
