using HotelApplication.Dtos;
using HotelApplication.Requests.Commands;
using HotelApplication.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace HotelPresentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Constructors
        public HotelController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        #endregion

        #region Endpoints
        /// <summary>
        /// Gets the list of all created hotels
        /// </summary>
        /// <returns>The list of all created hotels</returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllHotels()
        {
            var response = await _mediator.Send(new GetHotelsQuery());
            return Ok(response);
        }

        /// <summary>
        /// Gets the hotel with specified identifier, if exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The hotel with specified identifier, if exists</returns>
        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetHotelById(long id)
        {
            var response = await _mediator.Send(new GetHotelByIdQuery(id));
            return Ok(response);
        }

        /// <summary>
        /// Creates a new hotel, based on a specefied request
        /// </summary>
        /// <param name="request"></param>
        /// <returns>New created hotel</returns>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(CreateHotelCommand), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateHotel([FromBody] HotelDto hotelDto)
        {
            var response = await _mediator.Send(new CreateHotelCommand(hotelDto));
            return CreatedAtAction(nameof(GetHotelById),
                new { id = response }, response);
        }

        /// <summary>
        /// Delete hotel based on specified identifier, if exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteHotel(long id)
        {
            var response = await _mediator.Send(new DeleteHotelCommand(id));
            return Ok(response);
        }

        /// <summary>
        /// Update hotel's values based on request and id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns>Updated hotel</returns>
        [HttpPut]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateHotel(HotelDto request, long id)
        {
            var response = await _mediator.Send(new UpdateHotelCommand(request, id));
            return Ok(response);
        }
        #endregion
    }
}
