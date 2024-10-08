﻿using HotelApplication.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace HotelPresentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchHotelController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Constructors
        public SearchHotelController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        #endregion

        #region Endpoints
        /// <summary>
        /// Get a list of hotles sorted by price and then by location based on your current location
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns>Ordered list of hotels</returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllHotelsSortedByCurrentLocation(double latitude, double longitude, [FromQuery] int page, int sizePerPage)
        {
            var response = await _mediator.Send(new GetAllHotelsSortedByCurrentLocationQuery(latitude, longitude, page, sizePerPage));
            return Ok(response);
        }
        #endregion
    }
}
