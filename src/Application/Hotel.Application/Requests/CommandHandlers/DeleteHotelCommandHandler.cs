using AutoMapper;
using BuildingBlocks.CQRS;
using HotelApplication.Requests.Commands;
using HotelData.Abstractions;
using Microsoft.Extensions.Logging;

namespace HotelApplication.Requests.CommandHandlers
{
    public class DeleteHotelCommandHandler : ICommandHandler<DeleteHotelCommand, DeleteHotelCommandResult>
    {
        #region Fields
        private readonly IHotelRepository _hotelRepository;
        private readonly ILogger<DeleteHotelCommandHandler> _logger;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public DeleteHotelCommandHandler(IHotelRepository hotelRepository, ILogger<DeleteHotelCommandHandler> logger, IMapper mapper)
        {
            _hotelRepository = hotelRepository ?? throw new ArgumentNullException(nameof(hotelRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion

        #region Public methods
        public async Task<DeleteHotelCommandResult> Handle(DeleteHotelCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Start deleting hotel");

            var result = await _hotelRepository.DeleteAsync(command.Id);

            return new DeleteHotelCommandResult(result);
        }
        #endregion
    }
}
