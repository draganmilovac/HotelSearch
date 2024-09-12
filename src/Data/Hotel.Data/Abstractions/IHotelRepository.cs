namespace HotelData.Abstractions
{
    public interface IHotelRepository : IRepository<Models.Hotel>
    {
        /// <summary>
        /// Method that retrieves all created hotels in a list
        /// </summary>
        /// <returns>List of hotels</returns>
        Task<IEnumerable<Models.Hotel>> GetAllHotelAsync();

        /// <summary>
        /// Method that retrieves hotel from list based on hotel Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Hotel from hotel list</returns>
        Task<Models.Hotel> GetHotelAsync(long id);
    }
}
