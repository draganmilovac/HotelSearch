using BuildingBlocks.CQRS;
using HotelApplication.Requests.Commands;
using HotelData.Abstractions;
using Microsoft.Extensions.Logging;

namespace HotelApplication.Requests.CommandHandlers
{
    public class CreateHotelCommandHandler : ICommandHandler<CreateHotelCommand, CreateHotelCommandResult>
    {
        #region Fields
        private readonly IHotelRepository _hotelRepository;
        private readonly ILogger<CreateHotelCommandHandler> _logger;
        #endregion

        #region Constructors
        public CreateHotelCommandHandler(IHotelRepository hotelRepository, ILogger<CreateHotelCommandHandler> logger)
        {
            _hotelRepository = hotelRepository ?? throw new ArgumentNullException(nameof(hotelRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        #endregion

        #region Public methods
        public async Task<CreateHotelCommandResult> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            if(request.Hotel == null)
            {
                _logger.LogError("It's not possible to create new record.");
                return null;
            }
            
            var hotel = await _hotelRepository.CreateAsync(request.Hotel);

            return new CreateHotelCommandResult(hotel);
        }
        #endregion
    }
}
