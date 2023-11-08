using AwesomeShop.Core.Repositories;
using AwesomeShop.Core.Repositories.Orders;

namespace AwesomeShop.Application.UseCases.Orders.GetAll;

public class GetAllOrdersUseCase : IUseCase<NoInput, UseCaseResult<GetAllOrdersOutput>>
{
    //private readonly IOrderRepository _repository;
    private readonly IAzureTableOrderRepository _repository;

    //public GetAllOrdersUseCase(IOrderRepository repository)
    public GetAllOrdersUseCase(IAzureTableOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<UseCaseResult<GetAllOrdersOutput>> Execute(NoInput input = null)
    {
        var orders = await _repository.GetAll();

        var output = new GetAllOrdersOutput(orders);

        return new UseCaseResult<GetAllOrdersOutput>(output, true);
    }
}