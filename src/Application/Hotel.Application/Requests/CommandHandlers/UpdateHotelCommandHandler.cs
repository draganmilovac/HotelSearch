using AutoMapper;
using BuildingBlocks.CQRS;
using BuildingBlocks.Exceptions;
using HotelApplication.Dtos;
using HotelApplication.Requests.Commands;
using HotelData.Abstractions;
using HotelData.Models;
using Microsoft.Extensions.Logging;

namespace HotelApplication.Requests.CommandHandlers
{

    internal class UpdateHotelCommandHandler : ICommandHandler<UpdateHotelCommand, UpdateHotelCommandResult>
    {
        #region Fields
        private readonly IHotelRepository _hotelRepository;
        private readonly ILogger<UpdateHotelCommandHandler> _logger;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public UpdateHotelCommandHandler(IHotelRepository hotelRepository, ILogger<UpdateHotelCommandHandler> logger, IMapper mapper)
        {
            _hotelRepository = hotelRepository ?? throw new ArgumentNullException(nameof(hotelRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion

        #region Public methods
        public async Task<UpdateHotelCommandResult> Handle(UpdateHotelCommand command, CancellationToken cancellationToken)
        {
            var hotel = _mapper.Map<Hotel>(command.Hotel);

            if (hotel == null)
            {
                _logger.LogError($"Hotel with id:{command.Id} does not exist");
                throw new BadRequestException($"It's not possible to update hotel with id:{command.Id}");
            }

            _logger.LogInformation($"Start updating hotel with id:{hotel.Id}");
            var hotelToUpdate = await _hotelRepository.UpdateAsync(hotel, command.Id);
            var updatedHotel = _mapper.Map<HotelDto>(hotelToUpdate);
            _logger.LogInformation($"Hotel with id:{hotel.Id} is updated");

            return new UpdateHotelCommandResult(updatedHotel);
        }
        #endregion
    }
}
