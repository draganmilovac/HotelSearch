﻿namespace Hotel.Infrastructure.Models
{
    //List of hotels that is registered as a singleton
    //and can be used at the application level
    //and is alive while the application is alive
    public class Hotels : List<HotelData.Models.Hotel>
    {
    }
}
