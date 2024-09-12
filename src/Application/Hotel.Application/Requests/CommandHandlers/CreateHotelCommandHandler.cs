using AutoMapper;
using BuildingBlocks.CQRS;
using HotelApplication.Requests.Commands;
using HotelData.Abstractions;
using HotelData.Models;
using Microsoft.Extensions.Logging;

namespace HotelApplication.Requests.CommandHandlers
{
    public class CreateHotelCommandHandler : ICommandHandler<CreateHotelCommand, CreateHotelCommandResult>
    {
        #region Fields
        private readonly IHotelRepository _hotelRepository;
        private readonly ILogger<CreateHotelCommandHandler> _logger;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public CreateHotelCommandHandler(IHotelRepository hotelRepository, ILogger<CreateHotelCommandHandler> logger, IMapper mapper)
        {
            _hotelRepository = hotelRepository ?? throw new ArgumentNullException(nameof(hotelRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion

        #region Public methods
        public async Task<CreateHotelCommandResult> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            if(request.HotelDto == null)
            {
                _logger.LogError("It's not possible to create new record.");
                return null;
            }
            var hotel = _mapper.Map<Hotel>(request.HotelDto);
            var response = await _hotelRepository.CreateAsync(hotel);

            return new CreateHotelCommandResult(response);
        }
        #endregion
    }
}
