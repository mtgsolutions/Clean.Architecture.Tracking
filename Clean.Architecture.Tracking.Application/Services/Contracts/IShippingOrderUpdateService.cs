using Clean.Architecture.Tracking.Application.Models.Inputs;
using Clean.Architecture.Tracking.Application.Models.Views;

namespace Clean.Architecture.Tracking.Application.Services.Contracts;

public interface IShippingOrderUpdateService
{
    Task AddUpdate(AddShippingOrderUpdateInputModel model);
    Task<List<ShippingOrderUpdateViewModel>> GetAllByCode(string number);
}
