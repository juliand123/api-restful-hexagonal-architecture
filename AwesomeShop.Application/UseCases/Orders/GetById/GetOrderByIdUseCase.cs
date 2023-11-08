using AwesomeShop.Core.Repositories;
using AwesomeShop.Core.Repositories.Orders;

namespace AwesomeShop.Application.UseCases.Orders.GetById;

public class GetOrderByIdUseCase : IUseCase<int, UseCaseResult<GetOrderByIdOutput>>
{
    //private readonly IOrderRepository _repository;
    private readonly IAzureTableOrderRepository _repository;

    //public GetOrderByIdUseCase(IOrderRepository repository)
    public GetOrderByIdUseCase(IAzureTableOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<UseCaseResult<GetOrderByIdOutput>> Execute(int input)
    {
        var order = await _repository.GetById(input);
        var output = new GetOrderByIdOutput(order);

        return new UseCaseResult<GetOrderByIdOutput>(output, true);
    }
}