using Ardalis.GuardClauses;
using FluentValidation;
using MediatR;
using Themis.Core.Models;
using Themis.Domain;

namespace Themis.Application
{
    public class PlaceExhibitionOrderHandler
        : IRequestHandler<PlaceExhibitionOrderRequest, PlaceExhibitionOrderResponse>
    {
        private readonly IOrderRepository _repository;
        private readonly IValidator<PlaceExhibitionOrderRequest> _validator;
        private readonly IPackageService _packageService;
        private readonly ILookupService _lookupService;
        private readonly IInventoryService _inventoryService;
        private readonly IRequestContextService _userInfoService;

        public PlaceExhibitionOrderHandler(IOrderRepository repository,
                                           IValidator<PlaceExhibitionOrderRequest> validator,
                                           IRequestContextService userInfoService,
                                           IPackageService packageService,
                                           ILookupService lookupService,
                                           IInventoryService inventoryService)
        {
            _repository = Guard.Against.Null(repository);
            _validator = Guard.Against.Null(validator);
            _userInfoService = Guard.Against.Null(userInfoService);
            _packageService = Guard.Against.Null(packageService);
            _lookupService = Guard.Against.Null(lookupService);
            _inventoryService = Guard.Against.Null(inventoryService);
        }

        public async Task<PlaceExhibitionOrderResponse> Handle(
              PlaceExhibitionOrderRequest request,
              CancellationToken ct)
        {
            Guard.Against.Null(request);

            if (await _validator.ValidateAsync(request,
                                               ct) is { IsValid: false } validationResult)
            {
                throw new ValidationException(validationResult, nameof(PlaceExhibitionOrderRequest));
            }

            var userId = _userInfoService.GetUserId();
            var trackingCode = TrackingCode.New();

            foreach (var item in request.Items)
            {
                var inventoryItemDto = await _inventoryService.GetAsync(item.OrderId);
                var packageDto = await _packageService.GetAsync(item.PackageId, inventoryItemDto.Price);
                var cityDto = await _lookupService.GetCityAsync(request.CityId);

                var inventoryItem = new InventoryItem(
                    new InventoryItemId(item.OrderId),
                    new FullName(inventoryItemDto.FullName),
                    new Car(inventoryItemDto.CarId,
                            inventoryItemDto.CarType,
                            inventoryItemDto.CarGeneration,
                            inventoryItemDto.CarBrand,
                            inventoryItemDto.CarModel,
                            inventoryItemDto.CarColor,
                            inventoryItemDto.CarYear),
                    new City(inventoryItemDto.CityId,
                             inventoryItemDto.CityTitle,
                             inventoryItemDto.CityDistrict),
                    new Mileage(inventoryItemDto.Kilometer),
                    Money.Toman(inventoryItemDto.Price));

                var orderItem = new OrderItem(
                    new Package(packageDto.Id,
                                packageDto.Name,
                                Money.Toman(packageDto.Price)),
                    new Appointment(item.Appointment.FromDateTime,
                                   item.Appointment.ToDateTime),
                    inventoryItem);

                var order = new NewExhibitionOrder(
                    OrderId.New(),
                    trackingCode,
                    new Customer(userId,
                                 request.FullName,
                                 request.PhoneNumber),
                    new City(cityDto.Id,
                             cityDto.Name,
                             cityDto.District),
                    orderItem);

                await _repository.CreateAsync(order, ct);
            }

            return new PlaceExhibitionOrderResponse(trackingCode.Value);
        }
    }
}
