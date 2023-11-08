using AwesomeShop.Core.Repositories;
using AwesomeShop.Core.Repositories.Orders;

namespace AwesomeShop.Application.UseCases.Orders.Add;

public class AddOrderUseCase : IAddOrderUseCase
{
    //private readonly IOrderRepository _repository;
    private readonly IAzureTableOrderRepository _repository;
    //public AddOrderUseCase(IOrderRepository repository)
    public AddOrderUseCase(IAzureTableOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Execute(AddOrderInput input)
    {
        var order = input.ToEntity();

        var id = await _repository.Add(order);

        return id;
    }
}